using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Domain.Infra.Mapping
{
    public class BuyMapping : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.ToTable("Buys");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.DateTime).IsRequired();
            builder.HasMany(b => b.Products).WithMany(p => p.Buys);
        }
    }
}