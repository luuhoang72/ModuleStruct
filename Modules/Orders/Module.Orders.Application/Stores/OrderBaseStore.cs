using Module.Bases.Application.Stores;
using Module.Bases.Domain.Models;
using Module.Orders.Infrastructure.Databases;

namespace Module.Orders.Application.Stores
{
    public class OrderBaseStore<T> : BaseStore<T, OrderDbContext, OrderDbOption>
        where T : BaseEntity, new()
    {
        public OrderBaseStore(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
