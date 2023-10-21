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
public class EmpresaController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public EmpresaController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpresaDto>>> Get()
{
    var Empresa = await _unitOfWork.Empresas.GetAllAsync();
    return _mapper.Map<List<EmpresaDto>>(Empresa);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EmpresaDto>> Get(int id)
{
    var Empresa = await _unitOfWork.Empresas.GetByIdAsync(id);
    return _mapper.Map<EmpresaDto>(Empresa);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<EmpresaDto>>> Get([FromQuery]Params EmpresaParams)
{
var Empresa = await _unitOfWork.Empresas.GetAllAsync(EmpresaParams.PageIndex,EmpresaParams.PageSize, EmpresaParams.Search, "" );
var listaEmpresasDto= _mapper.Map<List<EmpresaDto>>(Empresa.registros);
return new Pager<EmpresaDto>(listaEmpresasDto, Empresa.totalRegistros,EmpresaParams.PageIndex,EmpresaParams.PageSize,EmpresaParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Empresa>> Post(EmpresaDto EmpresaDto)
{
    var Empresa = _mapper.Map<Empresa>(EmpresaDto);
    _unitOfWork.Empresas.Add(Empresa);
    await _unitOfWork.SaveAsync();

    if (Empresa == null)
    {
        return BadRequest();
    }
    EmpresaDto.Id = Empresa.Id;
    return CreatedAtAction(nameof(Post), new { id = EmpresaDto.Id }, Empresa);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EmpresaDto>> Put(int id, [FromBody]EmpresaDto EmpresaDto)
{
    if (EmpresaDto == null)
    {
        return NotFound();
    }
    var Empresa = _mapper.Map<Empresa>(EmpresaDto);
    _unitOfWork.Empresas.Update(Empresa);
    await _unitOfWork.SaveAsync();
    return EmpresaDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<EmpresaDto>> Delete(int id)
{
    var Empresa = await _unitOfWork.Empresas.GetByIdAsync(id);
    if (Empresa == null)
    {
        return NotFound();
    }
    _unitOfWork.Empresas.Remove(Empresa);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}