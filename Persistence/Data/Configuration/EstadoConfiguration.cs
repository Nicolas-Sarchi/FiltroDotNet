using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estado");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.TipoEstado)
        .WithMany(p => p.Estados)
        .HasForeignKey(p => p.IdTipoEstadoFk);

        builder.HasData(
            new Estado {Id = 1, Descripcion = "Produccion", IdTipoEstadoFk = 1}
        );
    }
}