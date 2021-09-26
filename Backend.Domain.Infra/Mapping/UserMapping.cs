using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Domain.Infra.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(64).HasColumnType("nvarchar(64)");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(64).HasColumnType("nvarchar(64)");
            builder.Property(u => u.Password).IsRequired().HasMaxLength(20).HasColumnType("nvarchar(20)");
            builder.Property(u => u.Role).IsRequired().HasMaxLength(20).HasColumnType("nvarchar(20)");
        }
    }
}