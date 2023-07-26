
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(a => a.Id_cliente)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .IsRequired();

        builder.Property(a => a.Direccion)
        .IsRequired();

        builder.Property(a => a.Telefono)
        .IsRequired();
    }
}
