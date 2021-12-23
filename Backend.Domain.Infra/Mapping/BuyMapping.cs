using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Domain.Infra.Mapping
{
    public class BuyMapping : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.DateTime).IsRequired();
            builder.HasOne(b => b.User).WithMany(u => u.Buys);
            builder.HasMany(b => b.Products).WithMany(p => p.Buys);
        }
    }
}