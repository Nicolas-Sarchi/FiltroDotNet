using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
{
    public void Configure(EntityTypeBuilder<FormaPago> builder)
    {
        builder.ToTable("forma_pago");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new FormaPago {Id =1, Descripcion= "Efectivo"},
            new FormaPago {Id =2, Descripcion= "Tarjeta Credito"},
            new FormaPago {Id =3, Descripcion= "Tarjeta Debito"}
        );
    }
}