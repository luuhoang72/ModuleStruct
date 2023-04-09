using Module.Bases.Domain.Stores;
using Module.Invoices.Domain.Models;

namespace Module.Invoices.Domain.Stores
{
    public interface IInvoiceStore : IBaseStore<Invoice>
    {
    }
}
