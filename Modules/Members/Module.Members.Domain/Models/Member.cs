using Module.Bases.Domain.Models;

namespace Module.Members.Domain.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string YearOfBirth { get; set; } = null!;
        public string Avatar { get; set; } = null!;

        public string PID { get; set; } = null!; // CMND, CCCD

        public string Country { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
    }
}
