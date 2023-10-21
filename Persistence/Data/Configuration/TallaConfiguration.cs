using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class TallaConfiguration : IEntityTypeConfiguration<Talla>
{
    public void Configure(EntityTypeBuilder<Talla> builder)
    {
        builder.ToTable("talla");

        builder.HasIndex(t=> t.Descripcion).IsUnique();

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(10);

        builder.HasData(
            new Talla {Id =1, Descripcion= "S"},
            new Talla {Id =2, Descripcion= "M"},
            new Talla {Id =3, Descripcion= "L"},
            new Talla {Id =4, Descripcion= "XL"}
        );
    }
}