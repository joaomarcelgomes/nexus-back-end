using System;
using System.Linq.Expressions;
using Backend.Domain.Entities;

namespace Backend.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> Login(string email, string password)
            => x => x.Email == email && x.Password == password;
    }
}