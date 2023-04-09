using Module.Bases.Domain.Models;

namespace Module.Invoices.Domain.Models
{
    public class Invoice : BaseEntity
    {
        public string OrderId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string CustomerName { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
