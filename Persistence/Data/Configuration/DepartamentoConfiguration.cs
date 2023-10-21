using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");
        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.IdPaisFk);

        builder.HasData(
            new Departamento {Id =1, Nombre = "Santander", IdPaisFk = 1},
            new Departamento {Id =2, Nombre = "Antioquia", IdPaisFk = 1},
            new Departamento {Id =3, Nombre = "Boyaca", IdPaisFk = 1},
            new Departamento {Id =4, Nombre = "Magdalena", IdPaisFk = 1}
        );
    }
}