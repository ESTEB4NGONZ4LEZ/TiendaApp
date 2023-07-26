
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(a => a.Id_proveedor)
        .IsRequired();
        
        builder.Property(a => a.Nombre)
        .IsRequired();

        builder.Property(a => a.Direccion)
        .IsRequired();

        builder.Property(a => a.Telefono)
        .IsRequired();
    }
}
