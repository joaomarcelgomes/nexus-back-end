using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Shared.Pagination;

namespace Backend.Domain.Repositories
{
    public interface IBuyRepository
    {
        public void Create(Buy buy);
        public Task<List<Buy>> FindAll(PaginationFilter filter);
        public Task<Buy> FindById(PaginationFilter filter, Guid id);
    }
}