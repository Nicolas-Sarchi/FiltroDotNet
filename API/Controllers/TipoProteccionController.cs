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
public class TipoProteccionController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TipoProteccionController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TipoProteccionDto>>> Get()
{
    var TipoProteccion = await _unitOfWork.TipoProteccions.GetAllAsync();
    return _mapper.Map<List<TipoProteccionDto>>(TipoProteccion);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoProteccionDto>> Get(int id)
{
    var TipoProteccion = await _unitOfWork.TipoProteccions.GetByIdAsync(id);
    return _mapper.Map<TipoProteccionDto>(TipoProteccion);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TipoProteccionDto>>> Get([FromQuery]Params TipoProteccionParams)
{
var TipoProteccion = await _unitOfWork.TipoProteccions.GetAllAsync(TipoProteccionParams.PageIndex,TipoProteccionParams.PageSize, TipoProteccionParams.Search, "" );
var listaTipoProteccionsDto= _mapper.Map<List<TipoProteccionDto>>(TipoProteccion.registros);
return new Pager<TipoProteccionDto>(listaTipoProteccionsDto, TipoProteccion.totalRegistros,TipoProteccionParams.PageIndex,TipoProteccionParams.PageSize,TipoProteccionParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoProteccion>> Post(TipoProteccionDto TipoProteccionDto)
{
    var TipoProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
    _unitOfWork.TipoProteccions.Add(TipoProteccion);
    await _unitOfWork.SaveAsync();

    if (TipoProteccion == null)
    {
        return BadRequest();
    }
    TipoProteccionDto.Id = TipoProteccion.Id;
    return CreatedAtAction(nameof(Post), new { id = TipoProteccionDto.Id }, TipoProteccion);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoProteccionDto>> Put(int id, [FromBody]TipoProteccionDto TipoProteccionDto)
{
    if (TipoProteccionDto == null)
    {
        return NotFound();
    }
    var TipoProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
    _unitOfWork.TipoProteccions.Update(TipoProteccion);
    await _unitOfWork.SaveAsync();
    return TipoProteccionDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TipoProteccionDto>> Delete(int id)
{
    var TipoProteccion = await _unitOfWork.TipoProteccions.GetByIdAsync(id);
    if (TipoProteccion == null)
    {
        return NotFound();
    }
    _unitOfWork.TipoProteccions.Remove(TipoProteccion);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}