
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    // * ----- Metodo GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<CategoriasDto>> Get()
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        return _mapper.Map<List<CategoriasDto>>(categorias);
    }
    // * ----- Metodo GET por ID -----
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Get(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
        if (categoria == null) {
            return NotFound();
        }
        return _mapper.Map<CategoriaDto>(categoria);
    }
    // * ----- Metodo POST -----
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriasDto>> Post(CategoriasDto categorias)
    {
        var categoria = _mapper.Map<Categoria>(categorias);
        _unitOfWork.Categorias.Add(categoria);
        await _unitOfWork.SaveAsync();
        if (categoria == null) {
            return BadRequest();
        }
        categoria.Id = categoria.Id;
        return CreatedAtAction(nameof(Post), new {id = categoria.Id}, categoria);
    }
    // * ----- Metodo PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriasDto>> Put(int id, [FromBody]CategoriasDto categorias)
    {
        if (categorias == null) {
            return NotFound();
        }
        var categoria = _mapper.Map<Categoria>(categorias);
        _unitOfWork.Categorias.Update(categoria);
        await _unitOfWork.SaveAsync();
        return categorias;
    }
    // * ----- Metodo DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
        if (categoria == null) {
            return NotFound();
        }
        _unitOfWork.Categorias.Remove(categoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
