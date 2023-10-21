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
public class ColorController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public ColorController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ColorDto>>> Get()
{
    var Color = await _unitOfWork.Colors.GetAllAsync();
    return _mapper.Map<List<ColorDto>>(Color);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ColorDto>> Get(int id)
{
    var Color = await _unitOfWork.Colors.GetByIdAsync(id);
    return _mapper.Map<ColorDto>(Color);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<ColorDto>>> Get([FromQuery]Params ColorParams)
{
var Color = await _unitOfWork.Colors.GetAllAsync(ColorParams.PageIndex,ColorParams.PageSize, ColorParams.Search, "Id" );
var listaColorsDto= _mapper.Map<List<ColorDto>>(Color.registros);
return new Pager<ColorDto>(listaColorsDto, Color.totalRegistros,ColorParams.PageIndex,ColorParams.PageSize,ColorParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Color>> Post(ColorDto ColorDto)
{
    var Color = _mapper.Map<Color>(ColorDto);
    _unitOfWork.Colors.Add(Color);
    await _unitOfWork.SaveAsync();

    if (Color == null)
    {
        return BadRequest();
    }
    ColorDto.Id = Color.Id;
    return CreatedAtAction(nameof(Post), new { id = ColorDto.Id }, Color);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ColorDto>> Put(int id, [FromBody]ColorDto ColorDto)
{
    if (ColorDto == null)
    {
        return NotFound();
    }
    var Color = _mapper.Map<Color>(ColorDto);
    _unitOfWork.Colors.Update(Color);
    await _unitOfWork.SaveAsync();
    return ColorDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ColorDto>> Delete(int id)
{
    var Color = await _unitOfWork.Colors.GetByIdAsync(id);
    if (Color == null)
    {
        return NotFound();
    }
    _unitOfWork.Colors.Remove(Color);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}