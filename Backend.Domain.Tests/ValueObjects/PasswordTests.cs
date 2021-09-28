using Backend.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.ValueObjects
{
    [TestClass]
    public class PasswordTests
    {
        private readonly Password _valid = new("@Admin1234");
        private readonly Password _inValid = new("pass");

        [TestMethod]
        public void ShouldReturnSuccessWhenPasswordIsValid() 
            => Assert.AreEqual(_valid.IsValid, true);

        [TestMethod]
        public void ShouldReturnErrorWhenPasswordIsInValid() 
            => Assert.AreEqual(_inValid.IsValid, false);
    }
}