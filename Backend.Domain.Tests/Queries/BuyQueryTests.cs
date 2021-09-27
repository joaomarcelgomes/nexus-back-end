using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Entities;
using Backend.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Queries
{
    [TestClass]
    public class BuyQueryTests
    {
        private readonly List<Buy> _items;
        private readonly Guid _id;

        public BuyQueryTests()
        {
            var item = new Buy(new List<Product>()
            { new Product("Product 1", "The product 1", 2.0, 2) }, DateTime.Now);
            _items = new List<Buy> { item };

            _id = item.Id;
        }
        
        [TestMethod]
        public void ShouldReturnOneProductWhenProductExists()
        {
            var result = _items.AsQueryable().Where(BuyQueries.FindById(_id));
            Assert.AreEqual(1, result.Count());
        }
    }
}