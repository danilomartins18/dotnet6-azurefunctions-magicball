using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using func_magicballapp.Services;

namespace func_magicballapp
{
    public static class GetResponse
    {
        [FunctionName("GetResponse")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest request,
            ILogger logger)
        {
            try
            {
                var service = new MagicBallService(logger);
                var response = service.GetResponse(request.Query["q"]);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
