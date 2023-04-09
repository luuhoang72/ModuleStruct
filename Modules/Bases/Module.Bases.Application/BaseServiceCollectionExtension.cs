using Microsoft.Extensions.Configuration;
using Module.Bases.Infrastructure.Databases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BaseServiceCollectionExtension
    {
        public static IServiceCollection AddBasesServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetBaseQueryHandler).Assembly));
            //services.AddValidatorsFromAssemblyContaining(typeof(GetBaseQueryHandler), ServiceLifetime.Transient);

            services.Configure<BaseDbOption>(configuration.GetSection("DbOption"));
            services.AddSingleton<MongoDbContext<BaseDbOption>>();

            return services;
        }
    }
}
