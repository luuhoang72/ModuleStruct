using FluentValidation;
using Microsoft.Extensions.Configuration;
using Module.Members.Application.Queries;
using Module.Members.Application.Services;
using Module.Members.Application.Stores;
using Module.Members.Domain.Services;
using Module.Members.Domain.Stores;
using Module.Members.Infrastructure.Databases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MemberServiceCollectionExtension
    {
        public static IServiceCollection AddMembersServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetMemberQueryHandler).Assembly));
            services.AddValidatorsFromAssemblyContaining(typeof(GetMemberQueryHandler), ServiceLifetime.Transient);

            services.Configure<MemberDbOption>(configuration.GetSection("DbOption"));
            services.AddSingleton<MemberDbContext>();

            services.AddScoped<IMemberStore, MemberStore>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IMemberChangeStore, MemberChangeStore>();

            return services;
        }
    }
}
