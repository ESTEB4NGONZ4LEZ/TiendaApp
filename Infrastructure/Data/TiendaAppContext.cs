
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Datal;

public class TiendaAppContext : DbContext
{
    public TiendaAppContext(DbContextOptions<TiendaAppContext> options) : base(options)
    {
    }
    // * ----- DbSet ------
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Cliente>? Clientes { get; set; }
    public DbSet<Factura>? Facturas { get; set; }
    public DbSet<Producto>? Productos { get; set; }
    public DbSet<Proveedor>? Proveedores { get; set; }
    public DbSet<Venta>? Ventas { get; set; }
    // * ----- Carga automatica de las Configuraciones -----
    /* Este metodo asegura que todas las configuraciones definidas en la clase de configuracion que heredan de IEntityTypeConfiguration se apliquen cuando se construye la DB */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
