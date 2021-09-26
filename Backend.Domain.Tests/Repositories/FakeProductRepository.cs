using Backend.Domain.Entities;
using Backend.Domain.Repositories;

namespace Backend.Domain.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public void Create(Product product)
        {
        }
    }
}