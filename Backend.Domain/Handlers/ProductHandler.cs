using Backend.Domain.Commands;
using Backend.Domain.Commands.ProductCommands;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using Backend.Domain.Shared.Commands;
using FluentValidator;

namespace Backend.Domain.Handlers
{
    public class ProductHandler :
        Notifiable,
        ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository) => _repository = repository;

        public ICommandResult Handle(CreateProductCommand command)
        {
            if(!command.Validation())
                AddNotifications(command.Notifications);

            if (Invalid)
                return new GenericCommandResult(
                    false, "Please correct the fields below",
                    Notifications
                );

            var model = new Product(command.Name, command.Description, command.Price, command.Amount);

            _repository.Create(model);

            return new GenericCommandResult(true, "Product created successfully", model);
        }
    }
}