using System;
using System.Threading.Tasks;

namespace Core.Application.Ports.PricingClient
{
    public interface IExternalPricingClient
    {
        Task<decimal> GetDiscountAsync(long basePrice, DateTime expirationDate);
    }
}
