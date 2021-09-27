using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Infra.Data;
using Backend.Domain.Queries;
using Backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) => _context = context;

        public async void Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckEmail(string email) 
            => await _context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email) == null;

        public async Task<User> Login(string email, string password) 
            => await _context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(UserQueries.Login(email, password));
    }
}