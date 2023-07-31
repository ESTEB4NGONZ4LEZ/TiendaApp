
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    // * ----- Metodo GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ProveedoresDto>> Get()
    {
        var proveedores = await _unitOfWork.Proveedores.GetAllAsync();
        return _mapper.Map<List<ProveedoresDto>>(proveedores);
    }
    // * ----- Metodo GET por ID -----
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> Get(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null) {
            return NotFound();
        }
        return _mapper.Map<ProveedorDto>(proveedor);
    }
    // * ----- Metodo POST -----
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedoresDto>> Post(ProveedoresDto proveedores)
    {
        var proveedor = _mapper.Map<Proveedor>(proveedores);
        _unitOfWork.Proveedores.Add(proveedor);
        await _unitOfWork.SaveAsync();
        if (proveedor == null) {
            return BadRequest();
        }
        proveedor.Id = proveedor.Id;
        return CreatedAtAction(nameof(Post), new {id = proveedor.Id}, proveedor);
    }
    // * ----- Metodo PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedoresDto>> Put(int id, [FromBody]ProveedoresDto proveedores)
    {
        if (proveedores == null) {
            return NotFound();
        }
        var proveedor = _mapper.Map<Proveedor>(proveedores);
        _unitOfWork.Proveedores.Update(proveedor);
        await _unitOfWork.SaveAsync();
        return proveedores;
    }
    // * ----- Metodo DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null) {
            return NotFound();
        }
        _unitOfWork.Proveedores.Remove(proveedor);
        await _unitOfWork.SaveAsync();
        return NoContent(); 
    }
}