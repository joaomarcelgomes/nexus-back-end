using Backend.Domain.Shared.Entities;

namespace Backend.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}