using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("municipio");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Municipios)
        .HasForeignKey(p => p.IdDeptoFk);

        builder.HasData(
            new Municipio { Id = 1, Nombre = "Bucaramanga", IdDeptoFk = 1 },
            new Municipio { Id = 2, Nombre = "San Gil", IdDeptoFk = 1 },
            new Municipio { Id = 3, Nombre = "Medellin", IdDeptoFk = 2 }

        );
    }
}