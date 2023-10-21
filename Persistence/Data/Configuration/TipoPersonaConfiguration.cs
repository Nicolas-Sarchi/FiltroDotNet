using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.ToTable("tipo_persona");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);  

        builder.HasData(
            new TipoPersona {Id =1, Nombre= "Persona Natural"},
            new TipoPersona {Id =2, Nombre = "Persona Juridica"}
        );
    }
}