using System;
using System.Threading.Tasks;
using Core.Application.Ports.PricingClient;
using Infrastructure.PricingClient.Clients.Models;
using Shares.Http;

namespace Infrastructure.PricingClient.Clients
{
    public class ExternalPricingClient : IExternalPricingClient
    {
        public readonly IHttpClient _httpClient;
        public ExternalPricingClient(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<decimal> GetDiscountAsync(long basePrice, DateTime expirationDate)
        {
            var result = await _httpClient.GetAsync<DiscountResultDto>($"https://awesomepricing.com/api?price={basePrice}&expirationDate={expirationDate.ToUniversalTime()}");
            return result.Discount;
        }
    }
}
