using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Presentation.MyFunction.Models.System;

namespace Presentation.MyFunction.Functions.Http.System
{
    public class GetApplicationVersionFunction
    {
        [FunctionName("GetApplicationVersion")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "system/version")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new ApplicationVersionVm
            {
                Version = "1.0.0"
            });
        }
    }
}
