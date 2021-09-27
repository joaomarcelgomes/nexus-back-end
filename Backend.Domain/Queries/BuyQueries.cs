using System;
using System.Linq.Expressions;
using Backend.Domain.Entities;

namespace Backend.Domain.Queries
{
    public static class BuyQueries
    {
        public static Expression<Func<Buy, bool>> FindById(Guid id)
            => x => x.Id == id;
    }
}