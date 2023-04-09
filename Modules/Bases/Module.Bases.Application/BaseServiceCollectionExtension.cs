using FluentValidation;
using Microsoft.Extensions.Configuration;
using Module.Bases.Application.Events;
using Module.Bases.Domain.Actors;
using Module.Bases.Infrastructure.Databases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BaseServiceCollectionExtension
    {
        public static IServiceCollection AddBasesServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BaseEventHandler).Assembly));
            services.AddValidatorsFromAssemblyContaining(typeof(BaseEventHandler), ServiceLifetime.Transient);

            services.Configure<BaseDbOption>(configuration.GetSection("DbOption"));
            services.AddSingleton<MongoDbContext<BaseDbOption>>();

            services.AddSingleton<IEventManager, EventManager>();

            return services;
        }
    }
}
