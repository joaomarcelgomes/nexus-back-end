using Backend.Domain.Commands;
using Backend.Domain.Commands.UserCommands;
using Backend.Domain.Handlers;
using Backend.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Domain.Tests.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        private readonly UserHandler _handler = new UserHandler(new FakeUserRepository());
        private readonly CreateUserCommand _valid = new CreateUserCommand("Pedro", "pedro@domain.com", "@Admin1234", "Client");
        private readonly CreateUserCommand _inValid = new CreateUserCommand("roberto","roberto@.com", "senha", "Client");

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