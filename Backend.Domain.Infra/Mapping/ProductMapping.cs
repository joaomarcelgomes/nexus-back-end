using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Domain.Infra.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
        }
    }
}