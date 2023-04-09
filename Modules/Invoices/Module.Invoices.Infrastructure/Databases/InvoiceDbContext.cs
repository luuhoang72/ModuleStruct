using Microsoft.Extensions.Options;
using Module.Bases.Infrastructure.Databases;
using Module.Invoices.Domain.Models;
using MongoDB.Driver;

namespace Module.Invoices.Infrastructure.Databases
{
    public class InvoiceDbOption : BaseDbOption
    {
    }

    public class InvoiceDbContext : MongoDbContext<InvoiceDbOption>
    {
        public InvoiceDbContext(IOptions<InvoiceDbOption> options) : base(options, "iv")
        {
        }

        public IMongoCollection<Invoice> Invoices { get { return Get<Invoice>(); } }
    }
}
