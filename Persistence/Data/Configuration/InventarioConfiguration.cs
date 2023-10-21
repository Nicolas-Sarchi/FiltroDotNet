using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("inventario");
        builder.HasIndex(i => i.CodInventario).IsUnique();

        builder.Property(p => p.CodInventario)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ValorVtaCop)
        .IsRequired()
        .HasColumnType("decimal(10, 2)");

        builder.Property(p => p.ValorVtaUsd)
        .IsRequired()
        .HasColumnType("decimal(10, 2)");

        builder.HasOne(p => p.Prenda)
        .WithMany(p => p.Inventarios)
        .HasForeignKey(p => p.IdPrendaFk);

        builder.HasMany(e => e.Tallas)
        .WithMany(p => p.Inventarios)
        .UsingEntity<InventarioTalla>(
            j => j
                .HasOne(ep => ep.Talla)
                .WithMany(e => e.InventarioTallas)
                .HasForeignKey(ep => ep.IdTallaFk),
        
            j => j
                .HasOne(ep => ep.Inventario)
                .WithMany(p => p.InventarioTallas)
                .HasForeignKey(ep => ep.IdInventarioFK),
        
            j =>
            {
                j.HasKey(ep => new { ep.IdTallaFk , ep.IdInventarioFK });
            }
        );

        builder.HasData(
            new Inventario {Id= 1, CodInventario= "123", IdPrendaFk = 1, ValorVtaCop = 40000, ValorVtaUsd = 10}
        );
    }
}