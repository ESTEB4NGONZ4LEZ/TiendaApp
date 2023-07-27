
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(a => a.Id)
        .IsRequired();

        builder.Property(a => a.Nombre)
        .HasMaxLength(30)
        .IsRequired();

        builder.Property(a => a.Direccion)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(a => a.Telefono)
        .HasMaxLength(20)
        .IsRequired();
    }
}
