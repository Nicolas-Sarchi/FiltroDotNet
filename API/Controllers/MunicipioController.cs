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
public class MunicipioController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public MunicipioController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<MunicipioDto>>> Get()
{
    var Municipio = await _unitOfWork.Municipios.GetAllAsync();
    return _mapper.Map<List<MunicipioDto>>(Municipio);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MunicipioDto>> Get(int id)
{
    var Municipio = await _unitOfWork.Municipios.GetByIdAsync(id);
    return _mapper.Map<MunicipioDto>(Municipio);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<MunicipioDto>>> Get([FromQuery]Params MunicipioParams)
{
var Municipio = await _unitOfWork.Municipios.GetAllAsync(MunicipioParams.PageIndex,MunicipioParams.PageSize, MunicipioParams.Search, "Nombre" );
var listaMunicipiosDto= _mapper.Map<List<MunicipioDto>>(Municipio.registros);
return new Pager<MunicipioDto>(listaMunicipiosDto, Municipio.totalRegistros,MunicipioParams.PageIndex,MunicipioParams.PageSize,MunicipioParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Municipio>> Post(MunicipioDto MunicipioDto)
{
    var Municipio = _mapper.Map<Municipio>(MunicipioDto);
    _unitOfWork.Municipios.Add(Municipio);
    await _unitOfWork.SaveAsync();

    if (Municipio == null)
    {
        return BadRequest();
    }
    MunicipioDto.Id = Municipio.Id;
    return CreatedAtAction(nameof(Post), new { id = MunicipioDto.Id }, Municipio);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MunicipioDto>> Put(int id, [FromBody]MunicipioDto MunicipioDto)
{
    if (MunicipioDto == null)
    {
        return NotFound();
    }
    var Municipio = _mapper.Map<Municipio>(MunicipioDto);
    _unitOfWork.Municipios.Update(Municipio);
    await _unitOfWork.SaveAsync();
    return MunicipioDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MunicipioDto>> Delete(int id)
{
    var Municipio = await _unitOfWork.Municipios.GetByIdAsync(id);
    if (Municipio == null)
    {
        return NotFound();
    }
    _unitOfWork.Municipios.Remove(Municipio);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}