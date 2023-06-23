using FluentValidation;
using Mapster;
using MediatR;
using Module.Members.Domain.Services.Dtos;
using Module.Members.Domain.Services.Queries;
using Module.Members.Domain.Stores;

namespace Module.Members.Application.Queries
{
    public class GetMemberAllQueryValidator : AbstractValidator<GetMemberAllQuery>
    {
        public GetMemberAllQueryValidator() 
        {
        }
    }

    public class GetMemberAllQueryHandler : IRequestHandler<GetMemberAllQuery, List<MemberDto>?>
    {
        private readonly IMemberStore _memberStore;

        public GetMemberAllQueryHandler(IMemberStore memberStore)
        {
            _memberStore = memberStore;
        }

        public async Task<List<MemberDto>?> Handle(GetMemberAllQuery request, CancellationToken cancellationToken)
        {
            var members = await _memberStore.FindAsync(x => true);
            return members?.Adapt<List<MemberDto>>();
        }
    }

}
