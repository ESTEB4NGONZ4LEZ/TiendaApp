
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    private readonly TiendaAppContext _context;

    public CategoriaRepository(TiendaAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Categorias
        .ToListAsync();
    }
    public override async Task<Categoria> GetByIdAsync(int id)
    {
        return await _context.Categorias
        .Include(a => a.Productos)
        .FirstOrDefaultAsync(a => a.Id == id);
    }
}
