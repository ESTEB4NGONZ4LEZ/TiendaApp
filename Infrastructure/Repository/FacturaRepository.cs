
using Core.Entities;
using Core.Interface;
using Infrastructure.Datal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class FacturaRepository : GenericRepository<Factura>, IFactura
{
    private readonly TiendaAppContext _context;

    public FacturaRepository(TiendaAppContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Factura>> GetAllAsync()
    {
        return await _context.Facturas
        .ToListAsync();
    }
    public override async Task<Factura> GetByIdAsync(int id)
    {
        return await _context.Facturas
        .FirstOrDefaultAsync(a => a.Id == id);
    }
}
