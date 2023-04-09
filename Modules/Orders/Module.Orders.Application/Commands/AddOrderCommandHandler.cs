using FluentValidation;
using Mapster;
using MediatR;
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

        public AddOrderCommandHandler(IOrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();
            order.Id = Guid.NewGuid().ToString();

            await _orderStore.AddAsync(order);

            return order;
        }
    }
}
