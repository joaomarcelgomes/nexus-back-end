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
        private readonly ProductHandler _handler = new(new FakeProductRepository());
        private readonly CreateProductCommand _valid = new("Product 1", "The product", 2.0, 2);
        private readonly CreateProductCommand _inValid = new("", "", 0.0, 0);

        [TestMethod]
        public void ShouldCreateUserWhenCommandIsValid() 
            => Assert.AreEqual(_handler.Handle(_valid).Success, true);

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInvalid() 
            => Assert.AreEqual(_handler.Handle(_inValid).Success, false);
    }
}