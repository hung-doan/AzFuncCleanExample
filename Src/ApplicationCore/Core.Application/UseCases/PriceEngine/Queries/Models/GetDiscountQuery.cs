using System;

namespace Core.Application.UseCases.PriceEngine.Queries.Models
{
    public class GetDiscountQuery
    {
        public long Price { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
