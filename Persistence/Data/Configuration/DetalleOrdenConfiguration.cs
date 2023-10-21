using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("detalle_orden");
        builder.Property(p => p.CantidadProducir)
        .IsRequired()
        .HasColumnType("int");
        
        builder.Property(p => p.CantidadProducida)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Prenda)
        .WithMany(p => p.DetallesOrden)
        .HasForeignKey(p => p.IdPrendaFk);

        builder.HasOne(p => p.Orden)
        .WithMany(p => p.DetallesOrden)
        .HasForeignKey(p => p.IdOrdenFk);

        builder.HasOne(p => p.Color)
        .WithMany(p => p.DetallesOrden)
        .HasForeignKey(p => p.IdColorFk);

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.DetallesOrden)
        .HasForeignKey(p => p.IdEstadoFk);

        builder.HasData(
            new DetalleOrden {Id = 1, CantidadProducida = 3, CantidadProducir = 10, IdColorFk = 1, IdEstadoFk = 1, IdOrdenFk = 1, IdPrendaFk = 1},
            new DetalleOrden {Id = 2, CantidadProducida = 5, CantidadProducir = 6, IdColorFk = 2, IdEstadoFk = 1, IdOrdenFk = 1, IdPrendaFk = 1},
            new DetalleOrden {Id = 3, CantidadProducida = 10, CantidadProducir = 20, IdColorFk = 4, IdEstadoFk = 1, IdOrdenFk = 1, IdPrendaFk = 1}
        );
}}