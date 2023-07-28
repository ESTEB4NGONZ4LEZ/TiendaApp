
using Core.Entities;
using Core.Interface;
using Infrastructure.Datal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly TiendaAppContext _context;

    public ClienteRepository(TiendaAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
        .ToListAsync();
    }
    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .FirstOrDefaultAsync(a => a.Id == id);
    }
}
