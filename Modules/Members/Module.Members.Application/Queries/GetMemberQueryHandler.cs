using FluentValidation;
using Mapster;
using MediatR;
using Module.Members.Domain.Services.Dtos;
using Module.Members.Domain.Services.Queries;
using Module.Members.Domain.Stores;

namespace Module.Members.Application.Queries
{
    public class GetMemberQueryValidator : AbstractValidator<GetMemberQuery>
    {
        public GetMemberQueryValidator() 
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }

    public class GetMemberQueryHandler : IRequestHandler<GetMemberQuery, MemberDto?>
    {
        private readonly IMemberStore _memberStore;

        public GetMemberQueryHandler(IMemberStore memberStore)
        {
            _memberStore = memberStore;
        }

        public async Task<MemberDto?> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            var order = await _memberStore.GetByIdAsync(request.Id);
            return order?.Adapt<MemberDto?>();
        }
    }

}
