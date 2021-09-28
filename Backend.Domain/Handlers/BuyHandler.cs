using System;
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
            if(!command.Valid())
                AddNotifications(command.Notifications);

            if (Invalid)
                return new GenericCommandResult(
                    false, "Please correct the fields below",
                    Notifications
                );

            var model = new Buy(command.User, command.Products, DateTime.Now);

            _repository.Create(model);

            return new GenericCommandResult(true, "Buy made successfully", model);
        }
    }
}