
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("venta");

        builder.Property(a => a.Id_venta)
        .IsRequired();

        builder.HasOne(a => a.Factura)
        .WithMany(e => e.Ventas)
        .HasForeignKey(i => i.Id_factura)
        .IsRequired();

        builder.HasOne(a => a.Producto)
        .WithMany(e => e.Ventas)
        .HasForeignKey(i => i.Id_producto)
        .IsRequired();

        builder.Property(a => a.Cantidad)
        .IsRequired();
    }
}
