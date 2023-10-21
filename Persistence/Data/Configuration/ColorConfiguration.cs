using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("color");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(50);
        builder.HasData(
            new Color { Id = 1, Descripcion = "Rojo" },
            new Color { Id = 2, Descripcion = "Azul" },
            new Color { Id = 3, Descripcion = "Amarillo" },
            new Color { Id = 4, Descripcion = "Verde" }
        );
    }
}