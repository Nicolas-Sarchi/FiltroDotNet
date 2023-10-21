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
public class DetalleVentaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public DetalleVentaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get()
{
    var DetalleVenta = await _unitOfWork.DetalleVentas.GetAllAsync();
    return _mapper.Map<List<DetalleVentaDto>>(DetalleVenta);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleVentaDto>> Get(int id)
{
    var DetalleVenta = await _unitOfWork.DetalleVentas.GetByIdAsync(id);
    return _mapper.Map<DetalleVentaDto>(DetalleVenta);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<DetalleVentaDto>>> Get([FromQuery]Params DetalleVentaParams)
{
var DetalleVenta = await _unitOfWork.DetalleVentas.GetAllAsync(DetalleVentaParams.PageIndex,DetalleVentaParams.PageSize, DetalleVentaParams.Search, "" );
var listaDetalleVentasDto= _mapper.Map<List<DetalleVentaDto>>(DetalleVenta.registros);
return new Pager<DetalleVentaDto>(listaDetalleVentasDto, DetalleVenta.totalRegistros,DetalleVentaParams.PageIndex,DetalleVentaParams.PageSize,DetalleVentaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleVenta>> Post(DetalleVentaDto DetalleVentaDto)
{
    var DetalleVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
    _unitOfWork.DetalleVentas.Add(DetalleVenta);
    await _unitOfWork.SaveAsync();

    if (DetalleVenta == null)
    {
        return BadRequest();
    }
    DetalleVentaDto.Id = DetalleVenta.Id;
    return CreatedAtAction(nameof(Post), new { id = DetalleVentaDto.Id }, DetalleVenta);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleVentaDto>> Put(int id, [FromBody]DetalleVentaDto DetalleVentaDto)
{
    if (DetalleVentaDto == null)
    {
        return NotFound();
    }
    var DetalleVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
    _unitOfWork.DetalleVentas.Update(DetalleVenta);
    await _unitOfWork.SaveAsync();
    return DetalleVentaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<DetalleVentaDto>> Delete(int id)
{
    var DetalleVenta = await _unitOfWork.DetalleVentas.GetByIdAsync(id);
    if (DetalleVenta == null)
    {
        return NotFound();
    }
    _unitOfWork.DetalleVentas.Remove(DetalleVenta);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}