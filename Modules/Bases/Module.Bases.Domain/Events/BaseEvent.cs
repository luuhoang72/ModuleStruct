using MediatR;

namespace Module.Bases.Domain.Events
{
    public class BaseEvent : INotification
    {
        public object Message { get; set; }
    }
}
