using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Pagination;

namespace Backend.Domain.Tests.Repositories
{
    public class FakeBuyRepository : IBuyRepository
    {
        public void Create(Buy buy)
        {
        }

        public Task<List<Buy>> FindAll(PaginationFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<Buy> FindById(PaginationFilter filter, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}