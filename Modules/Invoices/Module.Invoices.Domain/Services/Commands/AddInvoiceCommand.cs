using MediatR;
using Module.Invoices.Domain.Models;

namespace Module.Invoices.Domain.Services.Commands
{
    public class AddInvoiceCommand : IRequest<Invoice>
    {
        public string OrderId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string CustomerName { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
