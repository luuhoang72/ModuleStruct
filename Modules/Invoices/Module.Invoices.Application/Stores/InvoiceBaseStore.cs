using Module.Bases.Application.Stores;
using Module.Bases.Domain.Models;
using Module.Invoices.Infrastructure.Databases;

namespace Module.Invoices.Application.Stores
{
    public class InvoiceBaseStore<T> : BaseStore<T, InvoiceDbContext, InvoiceDbOption>
        where T : BaseEntity, new()
    {
        public InvoiceBaseStore(InvoiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
