using Module.Bases.Domain.Models;

namespace Module.Orders.Domain.Services.Dtos
{
    public class OrderDto : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
