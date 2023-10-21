using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
{
    public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
    {
        builder.ToTable("insumo_prenda");
        builder.Property(p => p.Cantidad)
        .IsRequired()
        .HasColumnType("int");
        
        builder.HasData(
            new InsumoPrenda { IdInsumoFk = 1, IdPrendaFk = 1, Cantidad = 1 }
        );
    }
}