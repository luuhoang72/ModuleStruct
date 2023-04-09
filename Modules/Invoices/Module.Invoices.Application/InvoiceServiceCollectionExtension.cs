using FluentValidation;
using Microsoft.Extensions.Configuration;
using Module.Invoices.Application.Queries;
using Module.Invoices.Application.Stores;
using Module.Invoices.Domain.Stores;
using Module.Invoices.Infrastructure.Databases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InvoiceServiceCollectionExtension
    {
        public static IServiceCollection AddInvoicesServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetInvoiceQueryHandler).Assembly));
            services.AddValidatorsFromAssemblyContaining(typeof(GetInvoiceQueryHandler), ServiceLifetime.Transient);

            services.Configure<InvoiceDbOption>(configuration.GetSection("DbOption"));
            services.AddSingleton<InvoiceDbContext>();

            services.AddScoped<IInvoiceStore, InvoiceStore>();

            return services;
        }
    }
}
