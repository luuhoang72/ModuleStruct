using MediatR;
using Module.Members.Domain.Services.Dtos;

namespace Module.Members.Domain.Services.Queries
{
    public class GetMemberQuery : IRequest<MemberDto?>
    {
        public string Id { get; set; } = null!;
    }
}
