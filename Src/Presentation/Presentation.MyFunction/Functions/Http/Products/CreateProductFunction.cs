using System.Threading.Tasks;
using Core.Application.UseCases.Products.Commands;
using Core.Application.UseCases.Products.Commands.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Presentation.MyFunction.Models.Products;
using Shares.AzureFunction.Core.Extensions;
using Shares.AzureFunction.Core.Http;

namespace Presentation.MyFunction.Functions.Http.Products
{
    public class CreateProductFunction : HttpFunctionBase
    {
        public readonly IProductCommandHandler _productCommandHandler;
        public CreateProductFunction(IProductCommandHandler productCommandHandler)
        {
            _productCommandHandler = productCommandHandler;
        }

        [FunctionName("CreateProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "POST", Route = "Products")] HttpRequest req
            , ILogger log)
        {
            CreateProductVm requestData = await req.ReadJsonStringAsAsync<CreateProductVm>();

            await _productCommandHandler.HandleAsync(new CreateProductCommand()
            {
                Name = requestData.Name,
                ExpirationDate = requestData.ExpirationDate,
                Price = requestData.Price
            });
            return new OkResult();
        }
    }
}
