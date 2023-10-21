using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("empresa");
        builder.HasIndex(p => p.Nit).IsUnique();

        builder.Property(p => p.Nit)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.RazonSocial)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.RepresentanteLegal)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.FechaCreacion)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Empresas)
        .HasForeignKey(p => p.IdMunicipioFk);

        builder.HasData(
            new Empresa {Id = 1, FechaCreacion = DateOnly.Parse("2013-11-22"), IdMunicipioFk = 1, Nit = "12321423", RazonSocial = "asdfdasf", RepresentanteLegal=  "Paco"},
            new Empresa {Id = 2, FechaCreacion = DateOnly.Parse("2020-11-22"), IdMunicipioFk = 2, Nit = "3433423", RazonSocial = "dsfdsfsda", RepresentanteLegal=  "Pedro"}
        );
    }
}