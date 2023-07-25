
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Datal;

public class TiendaAppContext : DbContext
{
    public TiendaAppContext(DbContextOptions<TiendaAppContext> options) : base(options)
    {
    }
}
