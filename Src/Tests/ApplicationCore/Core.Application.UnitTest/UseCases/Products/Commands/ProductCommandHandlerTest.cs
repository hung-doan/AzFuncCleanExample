using System;
using System.Threading.Tasks;
using Core.Application.Ports.Persistence.Repositories;
using Core.Application.UseCases.PriceEngine.Queries;
using Core.Application.UseCases.PriceEngine.Queries.Models;
using Core.Application.UseCases.Products.Commands;
using Core.Application.UseCases.Products.Commands.Models;
using Core.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Core.Application.UnitTest.UseCases.Products.Commands
{
    [TestClass]
    public class ProductCommandHandlerTest
    {
        private readonly Mock<IPriceEngineQueryHandler> _pricingQueryHandlerMock = new Mock<IPriceEngineQueryHandler>();
        private readonly Mock<IProductRepository> _productRepositoryHandlerMock = new Mock<IProductRepository>();


        /// <summary>
        /// In this project. I define the Command Handler is a unit of work to be tested.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task HandleAsync_CreateProductCommandWithValidInput_SendCorrectObjectToRepository()
        {
            #region Arrange
            Product actualProductEntity = null;
            Product expectedProductEntity = new Product()
            {
                Name = "Test Name",
                Price = 12345789,
                ExpirationDate = DateTime.Now.AddDays(7),
                Discount = 0.2M
            };

            // Mock IPriceEngineQueryHandler to return Discount.
            _pricingQueryHandlerMock
                .Setup(e => e.HandleAsync(
                    It.Is<GetDiscountQuery>(i=> 
                        i.Price == expectedProductEntity.Price
                        && i.ExpirationDate.Equals(expectedProductEntity.ExpirationDate))
                    ))
                .ReturnsAsync(expectedProductEntity.Discount);

            // Mock IProductRepository to track saved object
            _productRepositoryHandlerMock
                .Setup(e => e.AddAsync(It.IsAny<Product>()))
                .Callback<Product>(input =>
                {
                    actualProductEntity = input;
                });

            IPriceEngineQueryHandler pricingQueryHandler = _pricingQueryHandlerMock.Object;
            IProductRepository productRepository = _productRepositoryHandlerMock.Object;

            #endregion

            #region Action
            IProductCommandHandler handler = new ProductCommandHandler(pricingQueryHandler, productRepository);
            await handler.HandleAsync(new CreateProductCommand()
            {
                Name = expectedProductEntity.Name,
                Price = expectedProductEntity.Price,
                ExpirationDate = expectedProductEntity.ExpirationDate
            });

            #endregion

            #region Assert
            Assert.AreEqual(expectedProductEntity.Name, actualProductEntity.Name, $"Name should be the same as the original input");
            Assert.AreEqual(expectedProductEntity.Price, actualProductEntity.Price, "Price should be the same as the original input");
            Assert.AreEqual(expectedProductEntity.ExpirationDate, actualProductEntity.ExpirationDate, "ExpirationDate should be the same as the original input");
            Assert.AreEqual(expectedProductEntity.Discount, actualProductEntity.Discount, "Discount should be the same as the result from pricing service");

            #endregion
        }
    }
}
