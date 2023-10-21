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
public class InventarioController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public InventarioController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<InventarioDto>>> Get()
{
    var Inventario = await _unitOfWork.Inventarios.GetAllAsync();
    return _mapper.Map<List<InventarioDto>>(Inventario);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<InventarioDto>> Get(int id)
{
    var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
    return _mapper.Map<InventarioDto>(Inventario);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<InventarioDto>>> Get([FromQuery]Params InventarioParams)
{
var Inventario = await _unitOfWork.Inventarios.GetAllAsync(InventarioParams.PageIndex,InventarioParams.PageSize, InventarioParams.Search, "" );
var listaInventariosDto= _mapper.Map<List<InventarioDto>>(Inventario.registros);
return new Pager<InventarioDto>(listaInventariosDto, Inventario.totalRegistros,InventarioParams.PageIndex,InventarioParams.PageSize,InventarioParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Inventario>> Post(InventarioDto InventarioDto)
{
    var Inventario = _mapper.Map<Inventario>(InventarioDto);
    _unitOfWork.Inventarios.Add(Inventario);
    await _unitOfWork.SaveAsync();

    if (Inventario == null)
    {
        return BadRequest();
    }
    InventarioDto.Id = Inventario.Id;
    return CreatedAtAction(nameof(Post), new { id = InventarioDto.Id }, Inventario);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<InventarioDto>> Put(int id, [FromBody]InventarioDto InventarioDto)
{
    if (InventarioDto == null)
    {
        return NotFound();
    }
    var Inventario = _mapper.Map<Inventario>(InventarioDto);
    _unitOfWork.Inventarios.Update(Inventario);
    await _unitOfWork.SaveAsync();
    return InventarioDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<InventarioDto>> Delete(int id)
{
    var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
    if (Inventario == null)
    {
        return NotFound();
    }
    _unitOfWork.Inventarios.Remove(Inventario);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}