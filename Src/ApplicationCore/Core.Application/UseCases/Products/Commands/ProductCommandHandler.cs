using System;
using System.Threading.Tasks;
using Core.Application.Exceptions;
using Core.Application.Ports.Persistence.Repositories;
using Core.Application.UseCases.PriceEngine.Queries;
using Core.Application.UseCases.PriceEngine.Queries.Models;
using Core.Application.UseCases.Products.Commands.Models;
using Core.Domain.Entities;

namespace Core.Application.UseCases.Products.Commands
{
    public class ProductCommandHandler : IProductCommandHandler
    {
        public readonly IPriceEngineQueryHandler _pricingQueryHandler;
        public readonly IProductRepository _productRepository;
        public ProductCommandHandler(
            IPriceEngineQueryHandler pricingQueryHandler,
            IProductRepository productRepository)
        {
            _pricingQueryHandler = pricingQueryHandler;
            _productRepository = productRepository;
        }
        public async Task HandleAsync(CreateProductCommand command)
        {
            if (command.ExpirationDate < DateTimeOffset.Now)
            {
                throw new ValidationException($"The ExpirationDate should not in the pass.");
            }

            decimal discount = await _pricingQueryHandler.HandleAsync(new GetDiscountQuery()
            {
                Price = command.Price,
                ExpirationDate = command.ExpirationDate
            });

            await _productRepository.AddAsync(new Product()
            {
                Name = command.Name,
                Price = command.Price,
                Discount = discount,
                ExpirationDate = command.ExpirationDate
            });
        }
    }
}
