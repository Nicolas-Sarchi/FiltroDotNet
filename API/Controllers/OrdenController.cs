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
    public class OrdenController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrdenController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrdenDto>>> Get()
        {
            var Orden = await _unitOfWork.Ordens.GetAllAsync();
            return _mapper.Map<List<OrdenDto>>(Orden);
        }

        [HttpGet("cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrdenByClientDto>>> GetordenesporCliente(string id)
        {
            var Orden = await _unitOfWork.Ordens.GetByClienteId(id);
            return _mapper.Map<List<OrdenByClientDto>>(Orden);
        }

        [HttpGet("Prendas/Produccion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PrendaDto>>> GetProduccion(int id)
        {
            var Orden = await _unitOfWork.Ordens.prendasProduccion(id);
            return _mapper.Map<List<PrendaDto>>(Orden);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrdenDto>> Get(int id)
        {
            var Orden = await _unitOfWork.Ordens.GetByIdAsync(id);
            return _mapper.Map<OrdenDto>(Orden);
        }
        [ApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<OrdenDto>>> Get([FromQuery] Params OrdenParams)
        {
            var Orden = await _unitOfWork.Ordens.GetAllAsync(OrdenParams.PageIndex, OrdenParams.PageSize, OrdenParams.Search, "Id");
            var listaOrdensDto = _mapper.Map<List<OrdenDto>>(Orden.registros);
            return new Pager<OrdenDto>(listaOrdensDto, Orden.totalRegistros, OrdenParams.PageIndex, OrdenParams.PageSize, OrdenParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Orden>> Post(OrdenDto OrdenDto)
        {
            var Orden = _mapper.Map<Orden>(OrdenDto);
            _unitOfWork.Ordens.Add(Orden);
            await _unitOfWork.SaveAsync();

            if (Orden == null)
            {
                return BadRequest();
            }
            OrdenDto.Id = Orden.Id;
            return CreatedAtAction(nameof(Post), new { id = OrdenDto.Id }, Orden);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrdenDto>> Put(int id, [FromBody] OrdenDto OrdenDto)
        {
            if (OrdenDto == null)
            {
                return NotFound();
            }
            var Orden = _mapper.Map<Orden>(OrdenDto);
            _unitOfWork.Ordens.Update(Orden);
            await _unitOfWork.SaveAsync();
            return OrdenDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrdenDto>> Delete(int id)
        {
            var Orden = await _unitOfWork.Ordens.GetByIdAsync(id);
            if (Orden == null)
            {
                return NotFound();
            }
            _unitOfWork.Ordens.Remove(Orden);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}