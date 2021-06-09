using Core.Application.UseCases.PriceEngine.Queries;
using Core.Application.UseCases.Products.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class ServiceCollectionExtension
    {
        public static void AddCoreApplication(this IServiceCollection services)
        {
            services.AddTransient<IProductCommandHandler, ProductCommandHandler>();
            services.AddTransient<IPriceEngineQueryHandler, PriceEngineQueryHandler>();
        }
    }
}
