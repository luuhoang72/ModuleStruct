using Module.Bases.Domain.Models;

namespace Module.Invoices.Domain.Services.Dtos
{
    public class InvoiceDto : BaseEntity
    {
        public string OrderId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string CustomerName { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
