using Backend.Domain.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Backend.Domain.Commands.ProductCommands
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public CreateProductCommand(string name, string description, double price, int amount)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
        }

        public string Name { get; }
        public string Description { get; }
        public double Price { get; }
        public int Amount { get; }

        public bool Valid()
        {
            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "The name must contain at least 3 characters")
                    .HasMinLen(Description, 3, "Description", "The description must contain at least 3 characters")
                    .IsNotNull(Price, "Price", "The price is required")
                    .IsNotNull(Amount, "Amount", "The amount is required")
            );
            
            if(Price <= 0)
                AddNotification("Price", "The price must be greater than 0");
            
            if(Amount <= 0)
                AddNotification("Amount", "The amount must be greater than 0");

            return IsValid;
        }
    }
}