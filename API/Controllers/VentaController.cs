
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class VentaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VentaController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    // * ----- Metodo GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<VentaDto>> Get()
    {
        var ventas = await _unitOfWork.Ventas.GetAllAsync();
        return _mapper.Map<List<VentaDto>>(ventas);
    }
    // * ----- Metodo GET por ID -----
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VentaDto>> Get(int id)
    {
        var venta = await _unitOfWork.Ventas.GetByIdAsync(id);
        if (venta == null) {
            return NotFound();
        }
        return _mapper.Map<VentaDto>(venta);
    }
    // * ----- Metodo POST -----
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VentaDto>> Post(VentaDto ventas)
    {
        var venta = _mapper.Map<Venta>(ventas);
        _unitOfWork.Ventas.Add(venta);
        await _unitOfWork.SaveAsync();
        if (venta == null) {
            return BadRequest();
        }
        venta.Id = venta.Id;
        return CreatedAtAction(nameof(Post), new {id = venta.Id}, venta);
    }
    // * ----- Metodo PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VentaDto>> Put(int id, [FromBody]VentaDto ventas)
    {
        if (ventas == null) {
            return NotFound();
        }
        var venta = _mapper.Map<Venta>(ventas);
        _unitOfWork.Ventas.Update(venta);
        await _unitOfWork.SaveAsync();
        return ventas;
    }
    // * ----- Metodo DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var venta = await _unitOfWork.Ventas.GetByIdAsync(id);
        if (venta == null) {
            return NotFound();
        }
        _unitOfWork.Ventas.Remove(venta);
        await _unitOfWork.SaveAsync();
        return NoContent(); 
    }
}