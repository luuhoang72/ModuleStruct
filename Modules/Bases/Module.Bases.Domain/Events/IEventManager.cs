namespace Module.Bases.Domain.Actors
{
    public interface IEventManager
    {
        void Publish<T>(T message, CancellationToken cancellationToken = default) where T : notnull;
    }
}
