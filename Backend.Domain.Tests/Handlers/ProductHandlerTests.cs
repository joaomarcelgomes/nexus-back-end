using Backend.Domain.Commands;
using Backend.Domain.Commands.ProductCommands;
using Backend.Domain.Handlers;
using Backend.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Handlers
{
    [TestClass]
    public class ProductHandlerTests
    {
        private readonly ProductHandler _handler = new ProductHandler(new FakeProductRepository());
        private readonly CreateProductCommand _valid = new CreateProductCommand("Product 1", "The product", 2.0, 2);
        private readonly CreateProductCommand _inValid = new CreateProductCommand("", "", 0.0, 0);
        
        [TestMethod]
        public void ShouldCreateUserWhenCommandIsValid()
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