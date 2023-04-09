using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Module.Bases.Domain.Events;

namespace Module.Bases.Application.Events
{
    public class BaseEventHandler : INotificationHandler<BaseEvent>
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(BaseEvent baseEvent, CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            if (mediator == null)
                return;

            await mediator.Send(baseEvent.Message, cancellationToken);
        }
    }
}
