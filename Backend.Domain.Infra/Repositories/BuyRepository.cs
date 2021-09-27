using Backend.Domain.Entities;
using Backend.Domain.Infra.Data;
using Backend.Domain.Repositories;

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
    }
}