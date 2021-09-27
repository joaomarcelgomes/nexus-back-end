using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Shared.Entities;

namespace Backend.Domain.Entities
{
    public class User : Entity
    {
        private IList<Buy> _buys;
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            _buys = new List<Buy>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public IReadOnlyCollection<Buy> Buys => _buys == null ? new List<Buy>() : _buys.ToArray();
    }
}