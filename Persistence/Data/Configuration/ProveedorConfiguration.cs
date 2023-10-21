using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.HasIndex(p => p.NitProveedor).IsUnique();

        builder.Property(p => p.NitProveedor)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50); 

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Proveedores)
        .HasForeignKey(p => p.IdTipoPersonaFk);

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Proveedores)
        .HasForeignKey(p => p.IdMunicipioFk);

        builder.HasData(
            new Proveedor{Id =1, IdMunicipioFk =1, IdTipoPersonaFk =1, NitProveedor= "23423", Nombre= "distriRopa"},
            new Proveedor{Id =2, IdMunicipioFk =2, IdTipoPersonaFk =1, NitProveedor= "445332", Nombre= "multiRopa"}
        );
    }
}