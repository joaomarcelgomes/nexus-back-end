using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Shared.Pagination;

namespace Backend.Domain.Repositories
{
    public interface IBuyRepository
    {
        void Create(Buy buy);
        Task<List<Buy>> FindAll(PaginationFilter filter);
        Task<Buy> FindById(PaginationFilter filter, Guid id);
    }
}