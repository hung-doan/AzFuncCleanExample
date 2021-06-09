using System.Threading.Tasks;
using Core.Application.UseCases.PriceEngine.Queries.Models;

namespace Core.Application.UseCases.PriceEngine.Queries
{
    public interface IPriceEngineQueryHandler
    {
        Task<decimal> HandleAsync(GetDiscountQuery query);
    }
}
