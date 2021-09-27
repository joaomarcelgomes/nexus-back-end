using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Infra.Data;
using Backend.Domain.Queries;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Pagination;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Product>> FindAll(PaginationFilter filter)
            => await _context
                .Products
                .AsNoTracking()
                .Skip((filter.PageNumber -1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

        public async Task<List<Product>> FindByName(PaginationFilter filter, string query) 
            => await _context
                .Products
                .AsNoTracking()
                .Where(ProductQueries.FindByName(query))
                .Skip((filter.PageNumber -1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
    }
}