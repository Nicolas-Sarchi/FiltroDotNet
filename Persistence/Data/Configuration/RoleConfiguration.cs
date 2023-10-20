using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {

        builder.ToTable("role");
        builder.Property(p => p.Id)
                .IsRequired();
        builder.Property(p => p.Name)
        .HasColumnName("rolName")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.HasData(
            new Role {Id = 1 , Name = "Admin"},
            new Role {Id = 2 , Name = "Employee"}
        );
    }
}
}