using Microsoft.Extensions.Options;
using Module.Bases.Infrastructure.Databases;
using Module.Orders.Domain.Models;
using MongoDB.Driver;

namespace Module.Orders.Infrastructure.Databases
{
    public class OrderDbOption : BaseDbOption
    {
    }

    public class OrderDbContext : MongoDbContext<OrderDbOption>
    {
        public OrderDbContext(IOptions<OrderDbOption> options) : base(options, "od")
        {
        }

        public IMongoCollection<Order> Orders { get { return Get<Order>(); } }
    }
}
