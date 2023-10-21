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
public class TipoEstadoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TipoEstadoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TipoEstadoDto>>> Get()
{
    var TipoEstado = await _unitOfWork.TipoEstados.GetAllAsync();
    return _mapper.Map<List<TipoEstadoDto>>(TipoEstado);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoEstadoDto>> Get(int id)
{
    var TipoEstado = await _unitOfWork.TipoEstados.GetByIdAsync(id);
    return _mapper.Map<TipoEstadoDto>(TipoEstado);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TipoEstadoDto>>> Get([FromQuery]Params TipoEstadoParams)
{
var TipoEstado = await _unitOfWork.TipoEstados.GetAllAsync(TipoEstadoParams.PageIndex,TipoEstadoParams.PageSize, TipoEstadoParams.Search, "" );
var listaTipoEstadosDto= _mapper.Map<List<TipoEstadoDto>>(TipoEstado.registros);
return new Pager<TipoEstadoDto>(listaTipoEstadosDto, TipoEstado.totalRegistros,TipoEstadoParams.PageIndex,TipoEstadoParams.PageSize,TipoEstadoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoEstado>> Post(TipoEstadoDto TipoEstadoDto)
{
    var TipoEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
    _unitOfWork.TipoEstados.Add(TipoEstado);
    await _unitOfWork.SaveAsync();

    if (TipoEstado == null)
    {
        return BadRequest();
    }
    TipoEstadoDto.Id = TipoEstado.Id;
    return CreatedAtAction(nameof(Post), new { id = TipoEstadoDto.Id }, TipoEstado);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoEstadoDto>> Put(int id, [FromBody]TipoEstadoDto TipoEstadoDto)
{
    if (TipoEstadoDto == null)
    {
        return NotFound();
    }
    var TipoEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
    _unitOfWork.TipoEstados.Update(TipoEstado);
    await _unitOfWork.SaveAsync();
    return TipoEstadoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoEstadoDto>> Delete(int id)
{
    var TipoEstado = await _unitOfWork.TipoEstados.GetByIdAsync(id);
    if (TipoEstado == null)
    {
        return NotFound();
    }
    _unitOfWork.TipoEstados.Remove(TipoEstado);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}