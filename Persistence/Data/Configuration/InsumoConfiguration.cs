using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("insumo");
        builder.HasIndex(i => i.Nombre).IsUnique();
        builder.Property(p => p.Nombre)

        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ValorUnit)
        .IsRequired()
        .HasColumnType("decimal(10, 2)");

        builder.Property(p => p.StockMin)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.StockMax)
       .IsRequired()
       .HasColumnType("int");

        builder
         .HasMany(p => p.Prendas)
         .WithMany(r => r.Insumos)
         .UsingEntity<InsumoPrenda>(

             j => j
             .HasOne(pt => pt.Prenda)
             .WithMany(t => t.InsumosPrenda)
             .HasForeignKey(ut => ut.IdPrendaFk),


             j => j
             .HasOne(et => et.Insumo)
             .WithMany(et => et.InsumosPrenda)
             .HasForeignKey(el => el.IdInsumoFk),

             j =>
             {
                 j.HasKey(t => new { t.IdPrendaFk, t.IdInsumoFk });

             });

        builder
    .HasMany(p => p.Proveedores)
    .WithMany(r => r.Insumos)
    .UsingEntity<InsumoProveedor>(

        j => j
        .HasOne(pt => pt.Proveedor)
        .WithMany(t => t.InsumosProveedor)
        .HasForeignKey(ut => ut.IdProveedorFk),


        j => j
        .HasOne(et => et.Insumo)
        .WithMany(et => et.InsumosProveedor)
        .HasForeignKey(el => el.IdInsumoFk),

        j =>
        {
            j.HasKey(t => new { t.IdProveedorFk, t.IdInsumoFk });

        });

        builder.HasData(
            new Insumo { Id = 1, Nombre = "Botones", StockMax = 20, StockMin = 10, ValorUnit = 12000 }
        );
    }
}