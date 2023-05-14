using FluentValidation;
using Mapster;
using MediatR;
using Module.Members.Domain.Models;
using Module.Members.Domain.Services.Commands;
using Module.Members.Domain.Stores;

namespace Module.Members.Application.Commands
{
    public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Member>
    {
        private readonly IMemberStore _memberStore;
        private readonly IMemberChangeStore _memberChangeStore;

        public UpdateMemberCommandHandler(
            IMemberStore memberStore,
            IMemberChangeStore memberChangeStore
            )
        {
            _memberStore = memberStore;
            _memberChangeStore = memberChangeStore;
        }

        public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var oldMember = await _memberStore.GetByIdAsync(request.Id)
                ?? throw new Exception($"UpdateMemberCommandHandler: Member Id {request.Id} not found.");

            var newMember = oldMember.Adapt<Member>();
            request.Adapt(newMember);

            await _memberStore.UpdateAsync(newMember.Id, newMember);

            Console.WriteLine("UpdateMemberCommandHandler, Member Id: {0}, time: {1}", newMember.Id, DateTime.UtcNow);

            var memberChanges = MemberChange.Compare(newMember, oldMember);
            var tasks = memberChanges.Select(x => _memberChangeStore.AddAsync(x));
            await Task.WhenAll(tasks);

            return newMember;
        }
    }
}
