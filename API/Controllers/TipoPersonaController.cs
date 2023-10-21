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
public class TipoPersonaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TipoPersonaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
{
    var TipoPersona = await _unitOfWork.TipoPersonas.GetAllAsync();
    return _mapper.Map<List<TipoPersonaDto>>(TipoPersona);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoPersonaDto>> Get(int id)
{
    var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
    return _mapper.Map<TipoPersonaDto>(TipoPersona);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TipoPersonaDto>>> Get([FromQuery]Params TipoPersonaParams)
{
var TipoPersona = await _unitOfWork.TipoPersonas.GetAllAsync(TipoPersonaParams.PageIndex,TipoPersonaParams.PageSize, TipoPersonaParams.Search, "" );
var listaTipoPersonasDto= _mapper.Map<List<TipoPersonaDto>>(TipoPersona.registros);
return new Pager<TipoPersonaDto>(listaTipoPersonasDto, TipoPersona.totalRegistros,TipoPersonaParams.PageIndex,TipoPersonaParams.PageSize,TipoPersonaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
{
    var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
    _unitOfWork.TipoPersonas.Add(TipoPersona);
    await _unitOfWork.SaveAsync();

    if (TipoPersona == null)
    {
        return BadRequest();
    }
    TipoPersonaDto.Id = TipoPersona.Id;
    return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersona);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody]TipoPersonaDto TipoPersonaDto)
{
    if (TipoPersonaDto == null)
    {
        return NotFound();
    }
    var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
    _unitOfWork.TipoPersonas.Update(TipoPersona);
    await _unitOfWork.SaveAsync();
    return TipoPersonaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoPersonaDto>> Delete(int id)
{
    var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
    if (TipoPersona == null)
    {
        return NotFound();
    }
    _unitOfWork.TipoPersonas.Remove(TipoPersona);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}