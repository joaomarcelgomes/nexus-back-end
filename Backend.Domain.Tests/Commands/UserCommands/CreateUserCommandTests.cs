using Backend.Domain.Commands.UserCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Commands.UserCommands
{
    [TestClass]
    public class CreateUserCommandTests
    {
        private readonly CreateUserCommand _valid = new("Pedro", "pedro@domain.com", "@Admin1234", "Client");
        private readonly CreateUserCommand _inValid = new("", "", "", "");

        [TestMethod]
        public void ShouldReturnSuccessWhenCommandIsValid() 
            => Assert.AreEqual(_valid.Valid(), true);

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInValid() 
            => Assert.AreEqual(_inValid.Valid(), false);
    }
}