using System;
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
    public class BuyRepository : IBuyRepository
    {
        private readonly DataContext _context;

        public BuyRepository(DataContext context) => _context = context;

        public async void Create(Buy buy)
        {
            await _context.Buys.AddAsync(buy);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Buy>> FindAll(PaginationFilter filter)
            => await _context
                .Buys
                .AsNoTracking()
                .Skip((filter.PageNumber -1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

        public async Task<Buy> FindById(PaginationFilter filter, Guid id)
            => await _context
                .Buys
                .Include(b => b.Products)
                .Where(BuyQueries.FindById(id))
                .Skip((filter.PageNumber -1) * filter.PageSize)
                .Take(filter.PageSize)
                .AsNoTracking()
                .FirstOrDefaultAsync();
    }
}