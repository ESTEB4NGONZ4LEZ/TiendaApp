
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClienteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    // * ----- Metodo GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ClientesDto>> Get()
    {
        var clientes = await _unitOfWork.Clientes.GetAllAsync();
        return _mapper.Map<List<ClientesDto>>(clientes);
    }
    // * ----- Metodo GET por ID -----
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (cliente == null) {
            return NotFound();
        }
        return _mapper.Map<ClienteDto>(cliente);
    }
    // * ----- Metodo POST -----
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientesDto>> Post(ClientesDto clientes)
    {
        var cliente = _mapper.Map<Cliente>(clientes);
        _unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.SaveAsync();
        if (cliente == null) {
            return BadRequest();
        }
        cliente.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new {id = cliente.Id}, cliente);
    }
    // * ----- Metodo PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientesDto>> Put(int id, [FromBody]ClientesDto clientes)
    {
        if (clientes == null) {
            return NotFound();
        }
        var cliente = _mapper.Map<Cliente>(clientes);
        _unitOfWork.Clientes.Update(cliente);
        await _unitOfWork.SaveAsync();
        return clientes;
    }
    // * ----- Metodo DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (cliente == null) {
            return NotFound();
        }
        _unitOfWork.Clientes.Remove(cliente);
        await _unitOfWork.SaveAsync();
        return NoContent(); 
    }
}
