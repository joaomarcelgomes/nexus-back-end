using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Shared.Entities;

namespace Backend.Domain.Entities
{
    public class Product : Entity
    {
        private readonly IList<Buy> _buys;
        public Product(string name, string description, double price, int amount)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
            _buys = new List<Buy>();
        }

        public string Name { get; }
        public string Description { get; }
        public double Price { get; }
        public int Amount { get; }
        public IEnumerable<Buy> Buys => _buys == null ? new List<Buy>() : _buys.ToArray();
    }
}