using Module.Orders.Domain.Services;
using System.Collections.Concurrent;

namespace Module.Orders.Application.Services
{
    public class LastRequestService : ILastRequestService
    {
        private readonly ConcurrentDictionary<string, DateTime> _dict = new();

        public Task<KeyValuePair<string, DateTime>?> GetAndRemoveAsync(DateTime dateTime)
        {
            var item = _dict.FirstOrDefault(x => x.Value <= dateTime);
            if (string.IsNullOrEmpty(item.Key))
                return Task.FromResult((KeyValuePair<string, DateTime>?)null);

            _dict.TryRemove(item);

            return Task.FromResult((KeyValuePair<string, DateTime>?)item);
        }

        public Task SaveAsync(string customerId)
        {
            _dict.AddOrUpdate(customerId, DateTime.UtcNow, (s, d) => DateTime.UtcNow);
            return Task.CompletedTask;
        }
    }
}
