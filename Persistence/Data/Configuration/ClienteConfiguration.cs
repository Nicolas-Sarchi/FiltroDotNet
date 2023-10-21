using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
  {
     public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");
        builder.HasIndex(p => p.IdCliente).IsUnique();

        builder.Property(p => p.IdCliente)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);
        builder.Property(p => p.FechaRegistro)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Clientes)
        .HasForeignKey(p => p.IdMunicipioFk);

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Clientes)
        .HasForeignKey(p => p.IdTipoPersonaFk);

        builder.HasData(
            new Cliente {Id = 1, FechaRegistro = DateOnly.Parse("2023-05-22"), IdCliente = "1101622982", IdMunicipioFk = 1, IdTipoPersonaFk = 1, Nombre = "Nicolas"},
            new Cliente {Id = 2, FechaRegistro = DateOnly.Parse("2023-04-22"), IdCliente = "113451682", IdMunicipioFk = 2, IdTipoPersonaFk = 1, Nombre = "Paco"}
        );
  }
  }
  