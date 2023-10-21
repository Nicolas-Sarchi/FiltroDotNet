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
[Authorize]
public class DetalleOrdenController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public DetalleOrdenController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<DetalleOrdenDto>>> Get()
{
    var DetalleOrden = await _unitOfWork.DetalleOrdens.GetAllAsync();
    return _mapper.Map<List<DetalleOrdenDto>>(DetalleOrden);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleOrdenDto>> Get(int id)
{
    var DetalleOrden = await _unitOfWork.DetalleOrdens.GetByIdAsync(id);
    return _mapper.Map<DetalleOrdenDto>(DetalleOrden);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<DetalleOrdenDto>>> Get([FromQuery]Params DetalleOrdenParams)
{
var DetalleOrden = await _unitOfWork.DetalleOrdens.GetAllAsync(DetalleOrdenParams.PageIndex,DetalleOrdenParams.PageSize, DetalleOrdenParams.Search, "" );
var listaDetalleOrdensDto= _mapper.Map<List<DetalleOrdenDto>>(DetalleOrden.registros);
return new Pager<DetalleOrdenDto>(listaDetalleOrdensDto, DetalleOrden.totalRegistros,DetalleOrdenParams.PageIndex,DetalleOrdenParams.PageSize,DetalleOrdenParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleOrden>> Post(DetalleOrdenDto DetalleOrdenDto)
{
    var DetalleOrden = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
    _unitOfWork.DetalleOrdens.Add(DetalleOrden);
    await _unitOfWork.SaveAsync();

    if (DetalleOrden == null)
    {
        return BadRequest();
    }
    DetalleOrdenDto.Id = DetalleOrden.Id;
    return CreatedAtAction(nameof(Post), new { id = DetalleOrdenDto.Id }, DetalleOrden);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleOrdenDto>> Put(int id, [FromBody]DetalleOrdenDto DetalleOrdenDto)
{
    if (DetalleOrdenDto == null)
    {
        return NotFound();
    }
    var DetalleOrden = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
    _unitOfWork.DetalleOrdens.Update(DetalleOrden);
    await _unitOfWork.SaveAsync();
    return DetalleOrdenDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleOrdenDto>> Delete(int id)
{
    var DetalleOrden = await _unitOfWork.DetalleOrdens.GetByIdAsync(id);
    if (DetalleOrden == null)
    {
        return NotFound();
    }
    _unitOfWork.DetalleOrdens.Remove(DetalleOrden);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}