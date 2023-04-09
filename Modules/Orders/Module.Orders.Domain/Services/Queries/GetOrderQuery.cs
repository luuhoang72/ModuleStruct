using MediatR;
using Module.Orders.Domain.Services.Dtos;

namespace Module.Orders.Domain.Services.Queries
{
    public class GetOrderQuery : IRequest<OrderDto?>
    {
        public string Id { get; set; } = null!;
    }
}
