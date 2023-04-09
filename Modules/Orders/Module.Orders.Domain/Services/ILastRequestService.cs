namespace Module.Orders.Domain.Services
{
    public interface ILastRequestService
    {
        Task<KeyValuePair<string, DateTime>?> GetAndRemoveAsync(DateTime dateTime);
        Task SaveAsync(string customerId);
    }
}
