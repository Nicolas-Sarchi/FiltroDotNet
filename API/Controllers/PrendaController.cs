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
    public class PrendaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PrendaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PrendaDto>>> Get()
        {
            var Prenda = await _unitOfWork.Prendas.GetAllAsync();
            return _mapper.Map<List<PrendaDto>>(Prenda);
        }

        [HttpGet("tipo-proteccion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PrendaGroupDto>>> GetporTipoProteccion()
        {
            var Prenda = await _unitOfWork.Prendas.PrendasPorTipoDeProteccion();
            return _mapper.Map<List<PrendaGroupDto>>(Prenda);
        }

        [HttpGet("Costo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> Getcosto(string id)
        {
            var Prenda = await _unitOfWork.Prendas.CostoPrenda(id);
            return Ok(Prenda);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PrendaDto>> Get(int id)
        {
            var Prenda = await _unitOfWork.Prendas.GetByIdAsync(id);
            return _mapper.Map<PrendaDto>(Prenda);
        }
        [ApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PrendaDto>>> Get([FromQuery] Params PrendaParams)
        {
            var Prenda = await _unitOfWork.Prendas.GetAllAsync(PrendaParams.PageIndex, PrendaParams.PageSize, PrendaParams.Search, "Id");
            var listaPrendasDto = _mapper.Map<List<PrendaDto>>(Prenda.registros);
            return new Pager<PrendaDto>(listaPrendasDto, Prenda.totalRegistros, PrendaParams.PageIndex, PrendaParams.PageSize, PrendaParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Prenda>> Post(PrendaDto PrendaDto)
        {
            var Prenda = _mapper.Map<Prenda>(PrendaDto);
            _unitOfWork.Prendas.Add(Prenda);
            await _unitOfWork.SaveAsync();

            if (Prenda == null)
            {
                return BadRequest();
            }
            PrendaDto.Id = Prenda.Id;
            return CreatedAtAction(nameof(Post), new { id = PrendaDto.Id }, Prenda);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PrendaDto>> Put(int id, [FromBody] PrendaDto PrendaDto)
        {
            if (PrendaDto == null)
            {
                return NotFound();
            }
            var Prenda = _mapper.Map<Prenda>(PrendaDto);
            _unitOfWork.Prendas.Update(Prenda);
            await _unitOfWork.SaveAsync();
            return PrendaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PrendaDto>> Delete(int id)
        {
            var Prenda = await _unitOfWork.Prendas.GetByIdAsync(id);
            if (Prenda == null)
            {
                return NotFound();
            }
            _unitOfWork.Prendas.Remove(Prenda);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}