using MediatR;
using Module.Members.Domain.Services.Dtos;

namespace Module.Members.Domain.Services.Queries
{
    public class GetMemberAllQuery : IRequest<List<MemberDto>?>
    {
        public int? Start { get; set; } = 0;
        public int? Length { get; set; } = 10;
    }
}
