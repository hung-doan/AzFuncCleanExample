using Core.Application;
using Core.Application.UseCases.Products.Commands;
using Infrastructure.Persistence;
using Infrastructure.PricingClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Presentation.MyFunction;
using Shares.Http;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Presentation.MyFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            RegisterServices(builder.Services);
        }
        private void RegisterServices(IServiceCollection serviceCollection)
        {
            // ApplicationCore
            serviceCollection.AddCoreApplication();
            
            // Infrastructure
            serviceCollection.AddInfrastructurePersistence();
            serviceCollection.AddInfrastructurePricingClient();

            // SharedBuildingBlocks
            serviceCollection.AddSharesHttp();
            serviceCollection.AddInfrastructurePricingClient();
        }
    }
}
