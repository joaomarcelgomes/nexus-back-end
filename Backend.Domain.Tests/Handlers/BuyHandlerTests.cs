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
        private readonly BuyHandler _handler = new BuyHandler(new FakeBuyRepository());
        private readonly CreateBuyCommand _valid = new CreateBuyCommand(
            new List<Product>{ new Product("Product 1", "The product", 2.0, 2) }
            );
        private readonly CreateBuyCommand _inValid = new CreateBuyCommand(new List<Product>());
        
        [TestMethod]
        public void ShouldCreateBuyWhenCommandIsValid()
        {
            var result = (GenericCommandResult) _handler.Handle(_valid);
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInvalid()
        {
            var result = (GenericCommandResult) _handler.Handle(_inValid);
            Assert.AreEqual(result.Success, false);
        }
    }
}