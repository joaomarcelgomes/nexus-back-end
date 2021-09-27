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

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int Amount { get; private set; }
        public IReadOnlyCollection<Buy> Buys => _buys == null ? new List<Buy>() : _buys.ToArray();
    }
}