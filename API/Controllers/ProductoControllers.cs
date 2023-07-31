
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductoController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    // * ----- Metodo GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ProductosDto>> Get()
    {
        var productos = await _unitOfWork.Productos.GetAllAsync();
        return _mapper.Map<List<ProductosDto>>(productos);
    }
    // * ----- Metodo GET por ID -----
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> Get(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) {
            return NotFound();
        }
        return _mapper.Map<ProductoDto>(producto);
    }
    // * ----- Metodo POST -----
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductosDto>> Post(ProductosDto productos)
    {
        var producto = _mapper.Map<Producto>(productos);
        _unitOfWork.Productos.Add(producto);
        await _unitOfWork.SaveAsync();
        if (producto == null) {
            return BadRequest();
        }
        producto.Id = producto.Id;
        return CreatedAtAction(nameof(Post), new {id = producto.Id}, producto);
    }
    // * ----- Metodo PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductosDto>> Put(int id, [FromBody]ProductosDto productos)
    {
        if (productos == null) {
            return NotFound();
        }
        var producto = _mapper.Map<Producto>(productos);
        _unitOfWork.Productos.Update(producto);
        await _unitOfWork.SaveAsync();
        return productos;
    }
    // * ----- Metodo DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) {
            return NotFound();
        }
        _unitOfWork.Productos.Remove(producto);
        await _unitOfWork.SaveAsync();
        return NoContent(); 
    }
}
