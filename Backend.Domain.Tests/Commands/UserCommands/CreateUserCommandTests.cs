using Backend.Domain.Commands.UserCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Commands.UserCommands
{
    [TestClass]
    public class CreateUserCommandTests
    {
        private readonly CreateUserCommand _valid = new CreateUserCommand("Pedro", "pedro@domain.com", "@Admin1234", "Client");
        private readonly CreateUserCommand _inValid = new CreateUserCommand("", "", "", "");

        [TestMethod]
        public void ShouldReturnSuccessWhenCommandIsValid()
        {
            _valid.Valid();
            Assert.AreEqual(_valid.IsValid, true);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInValid()
        {
            _inValid.Valid();
            Assert.AreEqual(_inValid.IsValid, false);
        }
    }
}