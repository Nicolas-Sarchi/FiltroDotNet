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
    public class ProveedorController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProveedorController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
        {
            var Proveedor = await _unitOfWork.Proveedores.GetAllAsync();
            return _mapper.Map<List<ProveedorDto>>(Proveedor);
        }

        [ApiVersion("1.0")]
        [HttpGet("personas-naturales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> GetPersonasNAturales()
        {
            var Proveedor = await _unitOfWork.Proveedores.GetPersonasNaturales();
            return _mapper.Map<List<ProveedorDto>>(Proveedor);
        }
        


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProveedorDto>> Get(int id)
        {
            var Proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            return _mapper.Map<ProveedorDto>(Proveedor);
        }
        [ApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProveedorDto>>> Get([FromQuery] Params ProveedorParams)
        {
            var Proveedor = await _unitOfWork.Proveedores.GetAllAsync(ProveedorParams.PageIndex, ProveedorParams.PageSize, ProveedorParams.Search, "");
            var listaProveedorsDto = _mapper.Map<List<ProveedorDto>>(Proveedor.registros);
            return new Pager<ProveedorDto>(listaProveedorsDto, Proveedor.totalRegistros, ProveedorParams.PageIndex, ProveedorParams.PageSize, ProveedorParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Proveedor>> Post(ProveedorDto ProveedorDto)
        {
            var Proveedor = _mapper.Map<Proveedor>(ProveedorDto);
            _unitOfWork.Proveedores.Add(Proveedor);
            await _unitOfWork.SaveAsync();

            if (Proveedor == null)
            {
                return BadRequest();
            }
            ProveedorDto.Id = Proveedor.Id;
            return CreatedAtAction(nameof(Post), new { id = ProveedorDto.Id }, Proveedor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody] ProveedorDto ProveedorDto)
        {
            if (ProveedorDto == null)
            {
                return NotFound();
            }
            var Proveedor = _mapper.Map<Proveedor>(ProveedorDto);
            _unitOfWork.Proveedores.Update(Proveedor);
            await _unitOfWork.SaveAsync();
            return ProveedorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProveedorDto>> Delete(int id)
        {
            var Proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (Proveedor == null)
            {
                return NotFound();
            }
            _unitOfWork.Proveedores.Remove(Proveedor);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}