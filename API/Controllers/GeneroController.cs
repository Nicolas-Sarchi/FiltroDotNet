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
public class GeneroController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public GeneroController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<GeneroDto>>> Get()
{
    var Genero = await _unitOfWork.Generos.GetAllAsync();
    return _mapper.Map<List<GeneroDto>>(Genero);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<GeneroDto>> Get(int id)
{
    var Genero = await _unitOfWork.Generos.GetByIdAsync(id);
    return _mapper.Map<GeneroDto>(Genero);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<GeneroDto>>> Get([FromQuery]Params GeneroParams)
{
var Genero = await _unitOfWork.Generos.GetAllAsync(GeneroParams.PageIndex,GeneroParams.PageSize, GeneroParams.Search, "" );
var listaGenerosDto= _mapper.Map<List<GeneroDto>>(Genero.registros);
return new Pager<GeneroDto>(listaGenerosDto, Genero.totalRegistros,GeneroParams.PageIndex,GeneroParams.PageSize,GeneroParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Genero>> Post(GeneroDto GeneroDto)
{
    var Genero = _mapper.Map<Genero>(GeneroDto);
    _unitOfWork.Generos.Add(Genero);
    await _unitOfWork.SaveAsync();

    if (Genero == null)
    {
        return BadRequest();
    }
    GeneroDto.Id = Genero.Id;
    return CreatedAtAction(nameof(Post), new { id = GeneroDto.Id }, Genero);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody]GeneroDto GeneroDto)
{
    if (GeneroDto == null)
    {
        return NotFound();
    }
    var Genero = _mapper.Map<Genero>(GeneroDto);
    _unitOfWork.Generos.Update(Genero);
    await _unitOfWork.SaveAsync();
    return GeneroDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<GeneroDto>> Delete(int id)
{
    var Genero = await _unitOfWork.Generos.GetByIdAsync(id);
    if (Genero == null)
    {
        return NotFound();
    }
    _unitOfWork.Generos.Remove(Genero);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}