using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Commands;
using Backend.Domain.Commands.BuyCommands;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Commands;
using FluentValidator;

namespace Backend.Domain.Handlers
{
    public class BuyHandler :
        Notifiable,
        ICommandHandler<CreateBuyCommand>
    {
        private readonly IBuyRepository _repository;

        public BuyHandler(IBuyRepository repository) => _repository = repository;

        public ICommandResult Handle(CreateBuyCommand command)
        {
            if(!command.Validation())
                AddNotifications(command.Notifications);

            var elements = command.Products.Select(x => x.Name).ToList();
            var products = _repository.FindByList(elements).Result;

            elements = new List<string>();

            if(products.Count == 0)
            {
                AddNotification("Products", "No products were found");
            }
            else
            {
                products.ForEach((x) => {
                    command.Products.ForEach((y) => {
                        x.Update(y.Amount);

                        if(x.Amount < 0)
                            AddNotification(x.Name, $"of the {(y.Amount)} item(s) ordered, there are only {x.Amount + y.Amount}");

                    });
                });
            }

            command.Products = new List<Product>();

            if (Invalid)
                return new GenericCommandResult(
                    false, "Please correct the fields below",
                    Notifications
                );

            var model = new Buy(command.User, command.Products, DateTime.Now);

            _repository.UpdateProducts(products);
            _repository.Create(model);

            return new GenericCommandResult(true, "Buy made successfully", model);
        }
    }
}