
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.Property(a => a.Id_producto)
        .IsRequired();

        builder.Property(a => a.Descripcion)
        .HasColumnType("text")
        .IsRequired();

        builder.Property(a => a.Precio)
        .IsRequired();

        builder.HasOne(a => a.Categoria)
        .WithMany(e => e.Productos)
        .HasForeignKey(i => i.Id_categoria)
        .IsRequired();

        builder.HasOne(a => a.Proveedor)
        .WithMany(e => e.Productos)
        .HasForeignKey(i => i.Id_proveedor)
        .IsRequired();
    }
}
