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
public class TallaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public TallaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<TallaDto>>> Get()
{
    var Talla = await _unitOfWork.Tallas.GetAllAsync();
    return _mapper.Map<List<TallaDto>>(Talla);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TallaDto>> Get(int id)
{
    var Talla = await _unitOfWork.Tallas.GetByIdAsync(id);
    return _mapper.Map<TallaDto>(Talla);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<TallaDto>>> Get([FromQuery]Params TallaParams)
{
var Talla = await _unitOfWork.Tallas.GetAllAsync(TallaParams.PageIndex,TallaParams.PageSize, TallaParams.Search, "Id" );
var listaTallasDto= _mapper.Map<List<TallaDto>>(Talla.registros);
return new Pager<TallaDto>(listaTallasDto, Talla.totalRegistros,TallaParams.PageIndex,TallaParams.PageSize,TallaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Talla>> Post(TallaDto TallaDto)
{
    var Talla = _mapper.Map<Talla>(TallaDto);
    _unitOfWork.Tallas.Add(Talla);
    await _unitOfWork.SaveAsync();

    if (Talla == null)
    {
        return BadRequest();
    }
    TallaDto.Id = Talla.Id;
    return CreatedAtAction(nameof(Post), new { id = TallaDto.Id }, Talla);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TallaDto>> Put(int id, [FromBody]TallaDto TallaDto)
{
    if (TallaDto == null)
    {
        return NotFound();
    }
    var Talla = _mapper.Map<Talla>(TallaDto);
    _unitOfWork.Tallas.Update(Talla);
    await _unitOfWork.SaveAsync();
    return TallaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<TallaDto>> Delete(int id)
{
    var Talla = await _unitOfWork.Tallas.GetByIdAsync(id);
    if (Talla == null)
    {
        return NotFound();
    }
    _unitOfWork.Tallas.Remove(Talla);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}