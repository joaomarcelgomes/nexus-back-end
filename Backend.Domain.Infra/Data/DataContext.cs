using Backend.Domain.Entities;
using Backend.Domain.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Backend.Domain.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping().Configure(builder.Entity<User>());
            new ProductMapping().Configure(builder.Entity<Product>());
        }
    }
}