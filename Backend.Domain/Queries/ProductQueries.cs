using System;
using System.Linq.Expressions;
using Backend.Domain.Entities;

namespace Backend.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> FindByName(string search) 
            => x => x.Name
                .Replace(" ", "")
                .ToLower()
                .Contains(search
                    .Replace(" ", "")
                    .ToLower()
                );
    }
}