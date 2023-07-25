
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Datal;

public class TiendaAppContext : DbContext
{
    public TiendaAppContext(DbContextOptions<TiendaAppContext> options) : base(options)
    {
    }
    // * ----- Carga automatica de las Configuraciones -----
    /* Este metodo asegura que todas las configuraciones definidas en la clase de configuracion que heredan de IEntityTypeConfiguration se apliquen cuando se construye la DB */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
