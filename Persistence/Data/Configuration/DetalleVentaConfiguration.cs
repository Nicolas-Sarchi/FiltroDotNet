using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("detalle_venta");

        builder.Property(p => p.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.ValorUnit)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.HasOne(p => p.Talla)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdTallaFk);

        builder.HasOne(p => p.Venta)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdVentaFk);

        builder.HasOne(p => p.Inventario)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdInventarioFK);

        builder.HasData(
            new DetalleVenta {Id =1, Cantidad = 2, IdTallaFk = 1, IdInventarioFK=  1, IdVentaFk=  1, ValorUnit = 50000},
            new DetalleVenta {Id =2, Cantidad = 1, IdTallaFk = 2, IdInventarioFK=  1, IdVentaFk=  1, ValorUnit = 5000},
            new DetalleVenta {Id =3, Cantidad = 1, IdTallaFk = 2, IdInventarioFK=  1, IdVentaFk=  1, ValorUnit = 10000}
        );
    }
}