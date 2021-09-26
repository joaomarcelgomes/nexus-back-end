using Backend.Domain.Commands;
using Backend.Domain.Commands.UserCommands;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Commands;
using Backend.Domain.ValueObjects;
using FluentValidator;

namespace Backend.Domain.Handlers
{
    public class UserHandler :
        Notifiable,
        ICommandHandler<CreateUserCommand>
    {

        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository) => _repository = repository;

        public ICommandResult Handle(CreateUserCommand command)
        {
            if(!command.Valid())
                AddNotifications(command.Notifications);

            if(!_repository.CheckEmail(command.Email).Result)
                AddNotification("Email", "This email is already in use");

            var password = new Password(command.Password);

            AddNotifications(password.Notifications);

            if (Invalid)
                return new GenericCommandResult(
                    false, "Please correct the fields below",
                    Notifications
                    );

            var model = new User(command.Name, command.Email, password.Address, command.Role);

            _repository.Create(model);

            return new GenericCommandResult(true, "User created successfully", model);
        }
    }
}