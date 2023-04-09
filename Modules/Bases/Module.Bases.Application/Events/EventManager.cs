using MediatR;
using Module.Bases.Domain.Actors;
using Module.Bases.Domain.Events;

namespace Module.Bases.Application.Events
{
    public class EventManager : IEventManager
    {
        private readonly IMediator _mediator;

        public EventManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Publish<T>(T message, CancellationToken cancellationToken = default) where T : notnull
        {
            _mediator.Publish(new BaseEvent
            {
                Message = message,
            }, cancellationToken);
        }
    }
}
