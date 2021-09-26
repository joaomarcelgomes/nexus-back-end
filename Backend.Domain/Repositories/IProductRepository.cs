using Backend.Domain.Entities;

namespace Backend.Domain.Repositories
{
    public interface IProductRepository
    {
        public void Create(Product product);
    }
}