using System.Collections.Generic;
using Backend.Domain.Commands.BuyCommands;
using Backend.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Commands.BuyCommands
{
    [TestClass]
    public class CreateBuyCommandTests
    {
        private readonly CreateBuyCommand _valid = new(
            new User("roberto", "roberto@domain.com", "@Admin1234", "Client"), 
        new List<Product>{ new("Product 1", "The product", 2.0, 2) }
        );
        private readonly CreateBuyCommand _inValid = new(
            new User("roberto", "roberto@domain.com", "@Admin1234", "Client"), 
            new List<Product>()
        );

        [TestMethod]
        public void ShouldReturnSuccessWhenListContainTheItem() 
            => Assert.AreEqual(_valid.Valid(), true);

        [TestMethod]
        public void ShouldReturnErrorWhenListNotContainTheItem() 
            => Assert.AreEqual(_inValid.Valid(), false);
    }
}