
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.ToTable("factura");

        builder.Property(a => a.Id_factura)
        .IsRequired();

        builder.Property(a => a.Fecha)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(a => a.Cliente)
        .WithMany(e => e.Facturas)
        .HasForeignKey(i => i.Id_cliente)
        .IsRequired();
    }
}
