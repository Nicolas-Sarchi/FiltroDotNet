using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.ToTable("prenda");
        builder.HasIndex(p => p.IdPrenda).IsUnique();

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ValorUnitCop)
        .IsRequired()
        .HasColumnType("decimal(10, 2)");

        builder.Property(p => p.ValorUnitUsd)
       .IsRequired()
       .HasColumnType("decimal(10, 2)");

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdEstadoFk);

        builder.HasOne(p => p.TipoProteccion)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdTipoProteccionFk);

        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdGeneroFk);

        builder.HasData(
            new Prenda { Id = 1, IdPrenda = "2343", IdEstadoFk = 1, IdGeneroFk = 1, Nombre = "Camiseta Hombre", IdTipoProteccionFk = 1, ValorUnitCop = 100000, ValorUnitUsd = 25 },
            new Prenda { Id = 2, IdPrenda = "2342343", IdEstadoFk = 1, IdGeneroFk = 2, Nombre = "Camiseta Mujer", IdTipoProteccionFk = 1, ValorUnitCop = 100000, ValorUnitUsd = 25 }
        );

    }
}