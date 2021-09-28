using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Shared.Entities;

namespace Backend.Domain.Entities
{
    public class User : Entity
    {
        private readonly IList<Buy> _buys;
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            _buys = new List<Buy>();
        }

        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public IEnumerable<Buy> Buys => _buys == null ? new List<Buy>() : _buys.ToArray();
    }
}