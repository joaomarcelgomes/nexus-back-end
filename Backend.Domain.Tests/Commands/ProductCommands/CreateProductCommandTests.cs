using Backend.Domain.Commands.ProductCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Commands.ProductCommands
{
    [TestClass]
    public class CreateProductCommandTests
    {
        private readonly CreateProductCommand _valid = new("Product 1", "The product", 2.0, 2);
        private readonly CreateProductCommand _inValid = new("", "", 0.0, 0);
        private readonly CreateProductCommand _inValidPrice = new("Product 1", "The product", -1.2, 2);
        private readonly CreateProductCommand _inValidAmount = new("Product 1", "The product", 2.0, 0);

        [TestMethod]
        public void ShouldReturnSuccessWhenProductIsValid() 
            => Assert.AreEqual(_valid.Valid(), true);

        [TestMethod]
        public void ShouldReturnErrorWhenProductIsInValid() 
            => Assert.AreEqual(_inValid.Valid(), false);

        [TestMethod]
        public void ShouldReturnErrorWhenPriceIsValid() 
            => Assert.AreEqual(_inValidPrice.Valid(), false);

        [TestMethod]
        public void ShouldReturnErrorWhenAmountIsInValid() 
            => Assert.AreEqual(_inValidAmount.Valid(), false);
    }
}