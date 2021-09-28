using System.Threading.Tasks;
using Backend.Domain.Entities;

namespace Backend.Domain.Repositories
{
    public interface IUserRepository
    {
        public void Create(User user);
        public Task<bool> CheckEmail(string email);
        public Task<User> Login(string email, string password);
    }
}