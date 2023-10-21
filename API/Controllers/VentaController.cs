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
public class VentaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public VentaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<VentaDto>>> Get()
{
    var Venta = await _unitOfWork.Ventas.GetAllAsync();
    return _mapper.Map<List<VentaDto>>(Venta);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<VentaDto>> Get(int id)
{
    var Venta = await _unitOfWork.Ventas.GetByIdAsync(id);
    return _mapper.Map<VentaDto>(Venta);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<VentaDto>>> Get([FromQuery]Params VentaParams)
{
var Venta = await _unitOfWork.Ventas.GetAllAsync(VentaParams.PageIndex,VentaParams.PageSize, VentaParams.Search, "" );
var listaVentasDto= _mapper.Map<List<VentaDto>>(Venta.registros);
return new Pager<VentaDto>(listaVentasDto, Venta.totalRegistros,VentaParams.PageIndex,VentaParams.PageSize,VentaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Venta>> Post(VentaDto VentaDto)
{
    var Venta = _mapper.Map<Venta>(VentaDto);
    _unitOfWork.Ventas.Add(Venta);
    await _unitOfWork.SaveAsync();

    if (Venta == null)
    {
        return BadRequest();
    }
    VentaDto.Id = Venta.Id;
    return CreatedAtAction(nameof(Post), new { id = VentaDto.Id }, Venta);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<VentaDto>> Put(int id, [FromBody]VentaDto VentaDto)
{
    if (VentaDto == null)
    {
        return NotFound();
    }
    var Venta = _mapper.Map<Venta>(VentaDto);
    _unitOfWork.Ventas.Update(Venta);
    await _unitOfWork.SaveAsync();
    return VentaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<VentaDto>> Delete(int id)
{
    var Venta = await _unitOfWork.Ventas.GetByIdAsync(id);
    if (Venta == null)
    {
        return NotFound();
    }
    _unitOfWork.Ventas.Remove(Venta);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}