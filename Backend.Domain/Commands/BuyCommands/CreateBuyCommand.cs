using System.Collections.Generic;
using Backend.Domain.Entities;
using Backend.Domain.Shared.Commands;
using FluentValidator;

namespace Backend.Domain.Commands.BuyCommands
{
    public class CreateBuyCommand : Notifiable, ICommand
    {
        public CreateBuyCommand(User user, List<Product> products)
        {
            User = user;
            Products = products;
        }

        public User User { get; }
        public List<Product> Products { get; set; }

        public bool Validation()
        {
            if(Products.Count == 0)
                AddNotification("Products", "The list must have at least 1 item");

            return Valid;
        }
    }
}