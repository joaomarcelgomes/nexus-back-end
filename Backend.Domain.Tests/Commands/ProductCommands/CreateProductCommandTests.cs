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
        {
            _valid.Valid();
            Assert.AreEqual(_valid.IsValid, true);
        }
        
        [TestMethod]
        public void ShouldReturnErrorWhenProductIsInValid()
        {
            _inValid.Valid();
            Assert.AreEqual(_inValid.IsValid, false);
        }
        
        [TestMethod]
        public void ShouldReturnErrorWhenPriceIsValid()
        {
            _inValidPrice.Valid();
            Assert.AreEqual(_inValidPrice.IsValid, false);
        }
        
        [TestMethod]
        public void ShouldReturnErrorWhenAmountIsInValid()
        {
            _inValidAmount.Valid();
            Assert.AreEqual(_inValidAmount.IsValid, false);
        }
    }
}