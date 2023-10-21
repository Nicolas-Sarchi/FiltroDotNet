using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
{
    public void Configure(EntityTypeBuilder<InventarioTalla> builder)
    {
        builder.ToTable("inventario_talla");

        builder.Property(p => p.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Talla)
        .WithMany(p => p.InventarioTallas)
        .HasForeignKey(p => p.IdTallaFk);

        builder.HasOne(p => p.Inventario)
        .WithMany(p => p.InventarioTallas)
        .HasForeignKey(p => p.IdInventarioFK);

        builder.HasData(
            new InventarioTalla {IdInventarioFK= 1, IdTallaFk= 1, Cantidad= 10}
        );
    }
}