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
public class FormaPagoController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public FormaPagoController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<FormaPagoDto>>> Get()
{
    var FormaPago = await _unitOfWork.FormaPagos.GetAllAsync();
    return _mapper.Map<List<FormaPagoDto>>(FormaPago);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<FormaPagoDto>> Get(int id)
{
    var FormaPago = await _unitOfWork.FormaPagos.GetByIdAsync(id);
    return _mapper.Map<FormaPagoDto>(FormaPago);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<FormaPagoDto>>> Get([FromQuery]Params FormaPagoParams)
{
var FormaPago = await _unitOfWork.FormaPagos.GetAllAsync(FormaPagoParams.PageIndex,FormaPagoParams.PageSize, FormaPagoParams.Search, "" );
var listaFormaPagosDto= _mapper.Map<List<FormaPagoDto>>(FormaPago.registros);
return new Pager<FormaPagoDto>(listaFormaPagosDto, FormaPago.totalRegistros,FormaPagoParams.PageIndex,FormaPagoParams.PageSize,FormaPagoParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<FormaPago>> Post(FormaPagoDto FormaPagoDto)
{
    var FormaPago = _mapper.Map<FormaPago>(FormaPagoDto);
    _unitOfWork.FormaPagos.Add(FormaPago);
    await _unitOfWork.SaveAsync();

    if (FormaPago == null)
    {
        return BadRequest();
    }
    FormaPagoDto.Id = FormaPago.Id;
    return CreatedAtAction(nameof(Post), new { id = FormaPagoDto.Id }, FormaPago);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<FormaPagoDto>> Put(int id, [FromBody]FormaPagoDto FormaPagoDto)
{
    if (FormaPagoDto == null)
    {
        return NotFound();
    }
    var FormaPago = _mapper.Map<FormaPago>(FormaPagoDto);
    _unitOfWork.FormaPagos.Update(FormaPago);
    await _unitOfWork.SaveAsync();
    return FormaPagoDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<FormaPagoDto>> Delete(int id)
{
    var FormaPago = await _unitOfWork.FormaPagos.GetByIdAsync(id);
    if (FormaPago == null)
    {
        return NotFound();
    }
    _unitOfWork.FormaPagos.Remove(FormaPago);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}