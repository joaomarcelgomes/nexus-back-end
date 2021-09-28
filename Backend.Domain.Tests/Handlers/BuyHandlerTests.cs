using System.Collections.Generic;
using Backend.Domain.Commands;
using Backend.Domain.Commands.BuyCommands;
using Backend.Domain.Entities;
using Backend.Domain.Handlers;
using Backend.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Handlers
{
    [TestClass]
    public class BuyHandlerTests
    {
        private readonly BuyHandler _handler = new(new FakeBuyRepository());
        private readonly CreateBuyCommand _valid = new(
            new User("roberto", "roberto@domain.com", "@Admin1234", "Client"), 
            new List<Product>{ new Product("Product 1", "The product", 2.0, 2) }
            );
        
        private readonly CreateBuyCommand _inValid = new(
            new User("roberto", "roberto@domain.com", "@Admin1234", "Client"), 
            new List<Product>()
            );

        [TestMethod]
        public void ShouldCreateBuyWhenCommandIsValid() 
            => Assert.AreEqual(_handler.Handle(_valid).Success, true);

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInvalid() 
            => Assert.AreEqual(_handler.Handle(_inValid).Success, false);
    }
}