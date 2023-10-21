using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.Linq;
using API.Helpers;
namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    // [Authorize]
    public class InsumoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsumoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InsumoDto>>> Get()
        {
            var Insumo = await _unitOfWork.Insumos.GetAllAsync();
            return _mapper.Map<List<InsumoDto>>(Insumo);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InsumoDto>> Get(int id)
        {
            var Insumo = await _unitOfWork.Insumos.GetByIdAsync(id);
            return _mapper.Map<InsumoDto>(Insumo);
        }
        [HttpGet("proveedor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedorInsumoDto>>> GetbyProveedor(string id)
        {
            var Insumo = await _unitOfWork.Proveedores.GetInsumosProveedor(id);
            return _mapper.Map<List<ProveedorInsumoDto>>(Insumo);
        }
        [ApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<InsumoDto>>> Get([FromQuery] Params InsumoParams)
        {
            var Insumo = await _unitOfWork.Insumos.GetAllAsync(InsumoParams.PageIndex, InsumoParams.PageSize, InsumoParams.Search, "");
            var listaInsumosDto = _mapper.Map<List<InsumoDto>>(Insumo.registros);
            return new Pager<InsumoDto>(listaInsumosDto, Insumo.totalRegistros, InsumoParams.PageIndex, InsumoParams.PageSize, InsumoParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Insumo>> Post(InsumoDto InsumoDto)
        {
            var Insumo = _mapper.Map<Insumo>(InsumoDto);
            _unitOfWork.Insumos.Add(Insumo);
            await _unitOfWork.SaveAsync();

            if (Insumo == null)
            {
                return BadRequest();
            }
            InsumoDto.Id = Insumo.Id;
            return CreatedAtAction(nameof(Post), new { id = InsumoDto.Id }, Insumo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InsumoDto>> Put(int id, [FromBody] InsumoDto InsumoDto)
        {
            if (InsumoDto == null)
            {
                return NotFound();
            }
            var Insumo = _mapper.Map<Insumo>(InsumoDto);
            _unitOfWork.Insumos.Update(Insumo);
            await _unitOfWork.SaveAsync();
            return InsumoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InsumoDto>> Delete(int id)
        {
            var Insumo = await _unitOfWork.Insumos.GetByIdAsync(id);
            if (Insumo == null)
            {
                return NotFound();
            }
            _unitOfWork.Insumos.Remove(Insumo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}