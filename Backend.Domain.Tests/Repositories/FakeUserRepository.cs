using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;

namespace Backend.Domain.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public void Create(User user) { }

        public Task<bool> CheckEmail(string email) => Task.FromResult(email != "roberto@.com");
        public Task<User> Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}