using FluentValidation;
using Mapster;
using MediatR;
using Module.Orders.Domain.Services.Dtos;
using Module.Orders.Domain.Services.Queries;
using Module.Orders.Domain.Stores;

namespace Module.Orders.Application.Queries
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator() 
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto?>
    {
        private readonly IOrderStore _orderStore;

        public GetOrderQueryHandler(IOrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        public async Task<OrderDto?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderStore.GetByIdAsync(request.Id);
            return order?.Adapt<OrderDto?>();
        }
    }

}
