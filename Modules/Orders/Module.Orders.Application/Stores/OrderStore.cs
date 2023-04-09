using Module.Orders.Domain.Models;
using Module.Orders.Domain.Stores;
using Module.Orders.Infrastructure.Databases;

namespace Module.Orders.Application.Stores
{
    public class OrderStore : OrderBaseStore<Order>, IOrderStore
    {
        public OrderStore(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
