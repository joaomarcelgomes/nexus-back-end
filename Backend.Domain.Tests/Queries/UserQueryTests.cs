using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Entities;
using Backend.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Queries
{
    [TestClass]
    public class UserQueryTests
    {
        private readonly List<User> _items;

        public UserQueryTests()
        {
            _items = new List<User>
            {
                new User("Pedro", "pedro@domain.com", "@Admin1234", "Client"),
                new User("Roberto", "roberto@domain.com", "@Admin1234", "Client"),
                new User("Jose", "jose@domain.com", "@Admin1234", "Client")
            };
        }
        
        [TestMethod]
        public void ShouldDoLoginWhenUserExist()
        {
            var result = _items.AsQueryable().Where(UserQueries.Login("jose@domain.com", "@Admin1234"));
            Assert.AreEqual(1, result.Count());
        }
    }
}