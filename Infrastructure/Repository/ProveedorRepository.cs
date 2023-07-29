
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly TiendaAppContext _context;

    public ProveedorRepository(TiendaAppContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
        .ToListAsync();
    }
    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
        .FirstOrDefaultAsync(a => a.Id == id);
    }
}
