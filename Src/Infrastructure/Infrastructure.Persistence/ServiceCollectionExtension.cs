using Core.Application.Ports.Persistence.Repositories;
using Core.Application.UseCases.PriceEngine.Queries;
using Core.Application.UseCases.Products.Commands;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructurePersistence(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
