
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly TiendaAppContext _context;

    public ProductoRepository(TiendaAppContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
        .ToListAsync();
    }
    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
        .FirstOrDefaultAsync(a => a.Id == id);
    }
}
