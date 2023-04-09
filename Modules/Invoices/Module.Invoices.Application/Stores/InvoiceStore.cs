using Module.Invoices.Domain.Models;
using Module.Invoices.Domain.Stores;
using Module.Invoices.Infrastructure.Databases;

namespace Module.Invoices.Application.Stores
{
    public class InvoiceStore : InvoiceBaseStore<Invoice>, IInvoiceStore
    {
        public InvoiceStore(InvoiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
