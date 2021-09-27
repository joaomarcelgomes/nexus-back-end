using Backend.Domain.Entities;
using Backend.Domain.Infra.Data;
using Backend.Domain.Repositories;

namespace Backend.Domain.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) => _context = context;

        public async void Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}