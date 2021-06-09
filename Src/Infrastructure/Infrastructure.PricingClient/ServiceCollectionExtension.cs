using Core.Application.Ports.Persistence.Repositories;
using Core.Application.Ports.PricingClient;
using Infrastructure.PricingClient.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.PricingClient
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructurePricingClient(this IServiceCollection services)
        {
            services.AddTransient<IExternalPricingClient, ExternalPricingClient>();
        }
    }
}
