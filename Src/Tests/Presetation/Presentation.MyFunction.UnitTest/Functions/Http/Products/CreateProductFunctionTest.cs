using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Ports.Persistence.Repositories;
using Core.Application.UseCases.PriceEngine.Queries;
using Core.Application.UseCases.PriceEngine.Queries.Models;
using Core.Application.UseCases.Products.Commands;
using Core.Application.UseCases.Products.Commands.Models;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.MyFunction.Functions.Http.Products;
using Presentation.MyFunction.Models.Products;
using Shares.AzureFunction.Core.Extensions;
using Shares.Common.ObjectSerializer;

namespace Presentation.MyFunction.UnitTest.Functions.Http.Products
{
    [TestClass]
    public class CreateProductFunctionTest
    {
        private readonly Mock<IProductCommandHandler>  _productCommandHandlerMock = new Mock<IProductCommandHandler>();
        private readonly Mock<HttpRequest> _httpRequestMock = new Mock<HttpRequest>();
        private readonly Mock<Shares.AzureFunction.Core.Extensions.HttpRequestExtensions.Handler> _httpRequestExtensionsHandlerMock = new Mock<Shares.AzureFunction.Core.Extensions.HttpRequestExtensions.Handler>();
        private readonly Mock<ILogger>  _loggerMock = new Mock<ILogger>();

        /// <summary>
        /// This is an example of Solitary unit test,
        /// where I define the presentation layer (controller) is one unit of test.
        /// Other component will be injected via mocking test double.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Run_ValidInput_TriggerCorrectCommand()
        {
            #region Arrange

            CreateProductCommand actualCommand = null;
            CreateProductCommand expectedCommand = new CreateProductCommand()
            {
                Name = "Test Name",
                Price = 12345789,
                ExpirationDate = DateTime.Now.AddDays(7)
            };
            CreateProductVm requestVm = new CreateProductVm()
            {
                Name =  expectedCommand.Name,
                Price = expectedCommand.Price,
                ExpirationDate = expectedCommand.ExpirationDate
            };

            // Mock IProductCommandHandler to track command object
            _productCommandHandlerMock.Setup(e => e.HandleAsync(It.IsAny<CreateProductCommand>()))
                .Callback<CreateProductCommand>((input) =>
                {
                    actualCommand = input;
                });

            // Mock HttpRequest to return the correct ViewModel
            _httpRequestExtensionsHandlerMock.Setup(e => e.ReadJsonStringAsAsync<CreateProductVm>(It.IsAny<HttpRequest>())).ReturnsAsync(requestVm);
            Shares.AzureFunction.Core.Extensions.HttpRequestExtensions.Handler.Instance =
                _httpRequestExtensionsHandlerMock.Object;
            #endregion

            #region Action
            CreateProductFunction func = new CreateProductFunction(_productCommandHandlerMock.Object);
            await func.Run(_httpRequestMock.Object, _loggerMock.Object);

            #endregion

            #region Assert
            Assert.AreEqual(expectedCommand.Name, actualCommand.Name, $"Name should be the same as the original input");
            Assert.AreEqual(expectedCommand.Price, actualCommand.Price, "Price should be the same as the original input");
            Assert.AreEqual(expectedCommand.ExpirationDate, actualCommand.ExpirationDate, "ExpirationDate should be the same as the original input");

            #endregion

        }
        
    }
}
