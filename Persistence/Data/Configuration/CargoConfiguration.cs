using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable("cargo");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.SueldoBase)
        .IsRequired()
        .HasColumnType("decimal(10, 2)");

        builder.HasData(
            new Cargo {Id = 1, Descripcion = "Supervisor"},
            new Cargo {Id = 2, Descripcion = "Cajero"}
        );

    }
}