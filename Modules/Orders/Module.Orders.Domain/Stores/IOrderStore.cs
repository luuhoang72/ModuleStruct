using Module.Bases.Domain.Stores;
using Module.Orders.Domain.Models;

namespace Module.Orders.Domain.Stores
{
    public interface IOrderStore : IBaseStore<Order>
    {
    }
}
