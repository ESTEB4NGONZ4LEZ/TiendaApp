
using Core.Entities;
using Core.Interface;
using Infrastructure.Datal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly TiendaAppContext _context;

    public VentaRepository(TiendaAppContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Ventas
        .ToListAsync();
    }
    public override async Task<Venta> GetByIdAsync(int id)
    {
        return await _context.Ventas
        .FirstOrDefaultAsync(a => a.Id == id);
    }
}
