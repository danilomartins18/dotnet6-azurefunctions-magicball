using System;
using func_magicballapp.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace func_magicballapp
{
    public class GetResponseRecurring
    {
        [FunctionName("GetResponseRecurring")]
        public static void Run([TimerTrigger("*/30 * * * * *")] TimerInfo myTimer, ILogger logger)
        {
            try
            {
                var service = new MagicBallService(logger);
                var response = service.GetResponse("any question");
                logger.LogInformation($"Answer this time: {response} | Date: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting response!");
            }


        }
    }
}
