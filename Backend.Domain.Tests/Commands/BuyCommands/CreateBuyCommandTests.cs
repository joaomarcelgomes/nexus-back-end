using System.Collections.Generic;
using Backend.Domain.Commands.BuyCommands;
using Backend.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Commands.BuyCommands
{
    [TestClass]
    public class CreateBuyCommandTests
    {
        private readonly CreateBuyCommand _valid;
        private readonly CreateBuyCommand _inValid;

        public CreateBuyCommandTests()
        {
            _valid = new CreateBuyCommand(new List<Product>{ new Product("Produto 1", "The product", 2.0, 2) });
            _inValid = new CreateBuyCommand(new List<Product>());
        }
        
        [TestMethod]
        public void ShouldReturnSuccessWhenListContainTheItem()
        {
            _valid.Valid();
            Assert.AreEqual(_valid.IsValid, true);
        }
        
        [TestMethod]
        public void ShouldReturnErrorWhenListNotContainTheItem()
        {
            _inValid.Valid();
            Assert.AreEqual(_inValid.IsValid, false);
        }
    }
}