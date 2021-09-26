using Backend.Domain.Shared.Entities;

namespace Backend.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, string description, double price, int amount)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int Amount { get; private set; }
    }
}