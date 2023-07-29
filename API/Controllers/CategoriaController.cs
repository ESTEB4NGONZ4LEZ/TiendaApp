
using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriaController : BaseApiController
{
    private readonly TiendaAppContext _context;
    private readonly IMapper _mapper;

    public CategoriaController(TiendaAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // * ----- Metodo GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<AreaDto>> Get()
    {
         var areas = await _UnitOfWork.Areas.GetAllAsync();
        return this.mapper.Map<List<AreaDto>>(areas);
    }
    // * ----- Metodo GET por ID -----
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> Get(string id)
    {
        var area = await _UnitOfWork.Areas.GetByIdAsync(id);
        if (area == null) {
            return NotFound();
        }
        return this.mapper.Map<AreaDto>(area);
    }
    // * ----- Metodo POST -----
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> Post(Area area)
    {
        //var area = this.mapper.Map<Area>(areac);
        this._UnitOfWork.Areas.Add(area);
        await _UnitOfWork.SaveAsync();
        if (area == null) {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = area.Id_area}, area);
        //return this.mapper.Map<AreaDto>(area);
    }
    // * ----- Metodo PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> Put(string id, [FromBody]Area area)
    {
        //var area = this.mapper.Map<Area>(areac);
        if (area == null) {
            return NotFound();
        }
        _UnitOfWork.Areas.Update(area);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<AreaDto>(area);
    }
    // * ----- Metodo DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(string id)
    {
        var area = await _UnitOfWork.Areas.GetByIdAsync(id);
        if (area == null) {
            return NotFound();
        }
        _UnitOfWork.Areas.Remove(area);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}
