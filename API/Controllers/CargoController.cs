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
public class CargoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public CargoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<CargoDto>>> Get()
{
    var Cargo = await _unitOfWork.Cargos.GetAllAsync();
    return _mapper.Map<List<CargoDto>>(Cargo);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CargoDto>> Get(int id)
{
    var Cargo = await _unitOfWork.Cargos.GetByIdAsync(id);
    return _mapper.Map<CargoDto>(Cargo);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<CargoDto>>> Get([FromQuery]Params CargoParams)
{
var Cargo = await _unitOfWork.Cargos.GetAllAsync(CargoParams.PageIndex,CargoParams.PageSize, CargoParams.Search, "Descripcion" );
var listaCargosDto= _mapper.Map<List<CargoDto>>(Cargo.registros);
return new Pager<CargoDto>(listaCargosDto, Cargo.totalRegistros,CargoParams.PageIndex,CargoParams.PageSize,CargoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Cargo>> Post(CargoDto CargoDto)
{
    var Cargo = _mapper.Map<Cargo>(CargoDto);
    _unitOfWork.Cargos.Add(Cargo);
    await _unitOfWork.SaveAsync();

    if (Cargo == null)
    {
        return BadRequest();
    }
    CargoDto.Id = Cargo.Id;
    return CreatedAtAction(nameof(Post), new { id = CargoDto.Id }, Cargo);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CargoDto>> Put(int id, [FromBody]CargoDto CargoDto)
{
    if (CargoDto == null)
    {
        return NotFound();
    }
    var Cargo = _mapper.Map<Cargo>(CargoDto);
    _unitOfWork.Cargos.Update(Cargo);
    await _unitOfWork.SaveAsync();
    return CargoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<CargoDto>> Delete(int id)
{
    var Cargo = await _unitOfWork.Cargos.GetByIdAsync(id);
    if (Cargo == null)
    {
        return NotFound();
    }
    _unitOfWork.Cargos.Remove(Cargo);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}