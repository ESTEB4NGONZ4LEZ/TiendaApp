
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class FacturaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FacturaController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    // * ----- Metodo GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<FacturasDto>> Get()
    {
        var facturas = await _unitOfWork.Facturas.GetAllAsync();
        return _mapper.Map<List<FacturasDto>>(facturas);
    }
    // * ----- Metodo GET por ID -----
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FacturaDto>> Get(int id)
    {
        var factura = await _unitOfWork.Facturas.GetByIdAsync(id);
        if (factura == null) {
            return NotFound();
        }
        return _mapper.Map<FacturaDto>(factura);
    }
    // * ----- Metodo POST -----
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FacturasDto>> Post(FacturasDto facturas)
    {
        var factura = _mapper.Map<Factura>(facturas);
        _unitOfWork.Facturas.Add(factura);
        await _unitOfWork.SaveAsync();
        if (factura == null) {
            return BadRequest();
        }
        factura.Id = factura.Id;
        return CreatedAtAction(nameof(Post), new {id = factura.Id}, factura);
    }
    // * ----- Metodo PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FacturasDto>> Put(int id, [FromBody]FacturasDto facturas)
    {
        if (facturas == null) {
            return NotFound();
        }
        var factura = _mapper.Map<Factura>(facturas);
        _unitOfWork.Facturas.Update(factura);
        await _unitOfWork.SaveAsync();
        return facturas;
    }
    // * ----- Metodo DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var factura = await _unitOfWork.Facturas.GetByIdAsync(id);
        if (factura == null) {
            return NotFound();
        }
        _unitOfWork.Facturas.Remove(factura);
        await _unitOfWork.SaveAsync();
        return NoContent(); 
    }
}