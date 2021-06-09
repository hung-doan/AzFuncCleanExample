using System;

namespace Core.Application.UseCases.Products.Commands.Models
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
