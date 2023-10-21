using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");
        builder.HasIndex(p => p.IdEmpleado).IsUnique();

        builder.Property(p => p.IdEmpleado)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.FechaIngreso)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Cargo)
        .WithMany(p => p.Empleados)
        .HasForeignKey(p => p.IdCargoFk);

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Empleados)
        .HasForeignKey(p => p.IdMunicipioFk);

        builder.HasData(
            new Empleado { Id =1, IdEmpleado = "1234324", Nombre = "Juan Carlos", FechaIngreso = DateOnly.Parse("2021-04-12"), IdCargoFk = 1, IdMunicipioFk = 2},
            new Empleado { Id =2, IdEmpleado = "44444", Nombre = "Paco", FechaIngreso = DateOnly.Parse("2023-01-12"), IdCargoFk = 2, IdMunicipioFk = 1},
            new Empleado { Id =3, IdEmpleado = "3432", Nombre = "David", FechaIngreso = DateOnly.Parse("2022-09-20"), IdCargoFk = 1, IdMunicipioFk = 2}
        );
    }
}