using System;
using Core.SharedKernel;
using Core.SharedKernel.Entities;

namespace Core.Domain.Entities
{
    public class Product : EntityBase<long>
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
