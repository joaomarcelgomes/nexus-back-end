using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Pagination;

namespace Backend.Domain.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public void Create(Product product)
        {
        }

        public Task<List<Product>> FindAll(PaginationFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Product>> FindByName(PaginationFilter filter, string query)
        {
            throw new System.NotImplementedException();
        }
    }
}