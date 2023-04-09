using FluentValidation;
using Mapster;
using MediatR;
using Module.Bases.Domain.Actors;
using Module.Invoices.Domain.Services.Commands;
using Module.Orders.Domain.Models;
using Module.Orders.Domain.Services.Commands;
using Module.Orders.Domain.Stores;

namespace Module.Orders.Application.Commands
{
    public class GetOrderQueryValidator : AbstractValidator<AddOrderCommand>
    {
        public GetOrderQueryValidator()
        {
        }
    }

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Order>
    {
        private readonly IOrderStore _orderStore;
        private readonly IEventManager _eventManager;

        public AddOrderCommandHandler(IOrderStore orderStore, IEventManager eventManager)
        {
            _orderStore = orderStore;
            _eventManager = eventManager;
        }

        public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();

            await _orderStore.AddAsync(order);

            Console.WriteLine("AddOrderCommand, Order Id: {0}, time: {1}", order.Id, DateTime.UtcNow);

            _eventManager.Publish(new AddInvoiceCommand
            {
                OrderId = order.Id,
                Name = order.Name,
                Description = order.Description,
            }, cancellationToken);

            return order;
        }
    }
}
