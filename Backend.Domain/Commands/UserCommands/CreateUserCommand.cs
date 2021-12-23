using Backend.Domain.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Backend.Domain.Commands.UserCommands
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        
        public bool Validation()
        {
            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "The name must contain at least 3 characters")
                    .IsEmail(Email, "Email", "Email invalid, to be valid must contain name + domain (ex: name@domain.com)")
                    .HasMinLen(Role, 3, "Role", "A role must contain at least 3 characters")
            );

            return Valid;
        }
    }
}