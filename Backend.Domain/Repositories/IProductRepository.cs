using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Shared.Pagination;

namespace Backend.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        Task<List<Product>> FindAll(PaginationFilter filter);
        Task<List<Product>> FindByName(PaginationFilter filter, string query);
    }
}