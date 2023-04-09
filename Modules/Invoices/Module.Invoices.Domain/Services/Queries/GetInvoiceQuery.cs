using MediatR;
using Module.Invoices.Domain.Services.Dtos;

namespace Module.Invoices.Domain.Services.Queries
{
    public class GetInvoiceQuery : IRequest<InvoiceDto?>
    {
        public string Id { get; set; } = null!;
    }
}
