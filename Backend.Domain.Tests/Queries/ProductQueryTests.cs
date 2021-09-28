using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Entities;
using Backend.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Queries
{
    [TestClass]
    public class ProductQueryTests
    {
        private readonly List<Product> _items;

        public ProductQueryTests()
        {
            _items = new List<Product>
            {
                new("Product 1", "The product 1", 2.0, 2),
                new("Product 2", "The product 2", 3.0, 3),
                new("Product 3", "The product 3", 4.0, 4)
            };
        }

        [TestMethod]
        public void ShouldReturnOneProductWhenProductExists()
        {
            var result = _items.AsQueryable().Where(ProductQueries.FindByName("Product 1"));
            Assert.AreEqual(1, result.Count());
        }
    }
}