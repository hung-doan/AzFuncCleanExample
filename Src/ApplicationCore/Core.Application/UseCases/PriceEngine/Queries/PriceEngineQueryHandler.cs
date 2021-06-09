using System.Threading.Tasks;
using Core.Application.Ports.PricingClient;
using Core.Application.UseCases.PriceEngine.Queries.Models;

namespace Core.Application.UseCases.PriceEngine.Queries
{
    public class PriceEngineQueryHandler : IPriceEngineQueryHandler
    {
        public readonly IExternalPricingClient _pricingClient;
        public PriceEngineQueryHandler(IExternalPricingClient pricingClient)
        {
            _pricingClient = pricingClient;
        }
        public async Task<decimal> HandleAsync(GetDiscountQuery query)
        {
            return await _pricingClient.GetDiscountAsync(query.Price, query.ExpirationDate);
        }
    }
}
