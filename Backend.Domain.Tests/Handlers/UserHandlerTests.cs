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
        private readonly UserHandler _handler = new(new FakeUserRepository());
        private readonly CreateUserCommand _valid = new("Pedro", "pedro@domain.com", "@Admin1234", "Client");
        private readonly CreateUserCommand _inValid = new("roberto","roberto@.com", "senha", "Client");

        [TestMethod]
        public void ShouldCreateUserWhenCommandIsValid() 
            => Assert.AreEqual(_handler.Handle(_valid).Success, true);

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInvalid() 
            => Assert.AreEqual(_handler.Handle(_inValid).Success, false);
    }
}