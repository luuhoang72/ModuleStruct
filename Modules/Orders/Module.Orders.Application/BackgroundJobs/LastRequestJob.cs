using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module.Orders.Domain.Services;

namespace Module.Orders.Application.BackgroundJobs
{
    public class LastRequestJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly int _delaySeconds = 10;

        public LastRequestJob(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var lastRequestService = scope.ServiceProvider.GetService<ILastRequestService>();

            if (lastRequestService == null)
                return;

            while (!stoppingToken.IsCancellationRequested)
            {
                var time = DateTime.UtcNow.AddSeconds(-_delaySeconds);
                var item = await lastRequestService.GetAndRemoveAsync(time);

                if (item != null)
                {
                    // update database
                    Console.WriteLine("Custmer Id: {0}, time: {1}", item?.Key, item?.Value);
                }
                else
                {
                    await Task.Delay(_delaySeconds * 1000, stoppingToken);
                }
            }
        }
    }
}
