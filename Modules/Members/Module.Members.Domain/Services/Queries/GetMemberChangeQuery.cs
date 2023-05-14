using MediatR;
using Module.Members.Domain.Models;

namespace Module.Members.Domain.Services.Queries
{
    public class GetMemberChangeQuery : IRequest<List<MemberChange>?>
    {
        public string MemberId { get; set; } = null!;
    }
}
