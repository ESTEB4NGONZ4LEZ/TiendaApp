
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("categoria");

        builder.Property(a => a.Id)
        .IsRequired();

        builder.Property(a => a.Descripcion)
        .HasColumnType("text")
        .IsRequired();
    }
}
