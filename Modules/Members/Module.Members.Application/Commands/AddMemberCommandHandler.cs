using FluentValidation;
using Mapster;
using MediatR;
using Module.Members.Domain.Models;
using Module.Members.Domain.Services.Commands;
using Module.Members.Domain.Stores;

namespace Module.Members.Application.Commands
{
    public class AddMemberCommandValidator : AbstractValidator<AddMemberCommand>
    {
        public AddMemberCommandValidator()
        {
        }
    }

    public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, Member>
    {
        private readonly IMemberStore _memberStore;

        public AddMemberCommandHandler(IMemberStore memberStore)
        {
            _memberStore = memberStore;
        }

        public async Task<Member> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Member>();

            await _memberStore.AddAsync(order);

            Console.WriteLine("AddOrderCommand, Order Id: {0}, time: {1}", order.Id, DateTime.UtcNow);

            return order;
        }
    }
}
