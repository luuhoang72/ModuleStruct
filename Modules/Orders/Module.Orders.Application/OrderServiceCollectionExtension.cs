using FluentValidation;
using Microsoft.Extensions.Configuration;
using Module.Orders.Application.BackgroundJobs;
using Module.Orders.Application.Queries;
using Module.Orders.Application.Services;
using Module.Orders.Application.Stores;
using Module.Orders.Domain.Services;
using Module.Orders.Domain.Stores;
using Module.Orders.Infrastructure.Databases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OrderServiceCollectionExtension
    {
        public static IServiceCollection AddOrdersServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetOrderQueryHandler).Assembly));
            services.AddValidatorsFromAssemblyContaining(typeof(GetOrderQueryHandler), ServiceLifetime.Transient);

            services.Configure<OrderDbOption>(configuration.GetSection("DbOption"));
            services.AddSingleton<OrderDbContext>();

            services.AddScoped<IOrderStore, OrderStore>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<ILastRequestService, LastRequestService>();
            services.AddHostedService<LastRequestJob>();

            return services;
        }
    }
}
