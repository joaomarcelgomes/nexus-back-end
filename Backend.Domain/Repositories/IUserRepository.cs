using System.Threading.Tasks;
using Backend.Domain.Entities;

namespace Backend.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        Task<bool> CheckEmail(string email);
    }
}