using System;

namespace Presentation.MyFunction.Models.Products
{
    public class CreateProductVm
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
