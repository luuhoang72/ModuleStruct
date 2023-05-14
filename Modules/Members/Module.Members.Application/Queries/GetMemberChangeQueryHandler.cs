using FluentValidation;
using MediatR;
using Module.Members.Domain.Models;
using Module.Members.Domain.Services.Queries;
using Module.Members.Domain.Stores;

namespace Module.Members.Application.Queries
{
    public class GetMemberChangeQueryValidator : AbstractValidator<GetMemberChangeQuery>
    {
        public GetMemberChangeQueryValidator() 
        {
            RuleFor(x => x.MemberId).NotNull().NotEmpty();
        }
    }

    public class GetMemberChangeQueryHandler : IRequestHandler<GetMemberChangeQuery, List<MemberChange>?>
    {
        private readonly IMemberChangeStore _memberChangeStore;

        public GetMemberChangeQueryHandler(IMemberChangeStore orderStore)
        {
            _memberChangeStore = orderStore;
        }

        public async Task<List<MemberChange>?> Handle(GetMemberChangeQuery request, CancellationToken cancellationToken)
        {
            var memberChanges = await _memberChangeStore.FindAsync(x => x.MemberId == request.MemberId);
            return memberChanges;
        }
    }

}
