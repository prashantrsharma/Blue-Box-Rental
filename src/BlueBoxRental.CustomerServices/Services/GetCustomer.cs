using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlueBoxRental.CustomerServices.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlueBoxRental.CustomerServices.Services
{
    public static class GetCustomer
    {
        [FunctionName("GetCustomer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "GetCustomer/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {

            try
            {
                log.LogInformation("GetCustomer function processed a request.");

                using (SakilaContext context = new SakilaContext())
                {
                    return new OkObjectResult(await context.Customer.Where(c=>c.CustomerId == id).SingleOrDefaultAsync());
                }
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    $"We apologize but something went wrong on our end.Exception:{ex.Message}");
            }
            finally
            {
                log.LogInformation("GetCustomer function has finished processing a request.");
            }
        }
    }
}
