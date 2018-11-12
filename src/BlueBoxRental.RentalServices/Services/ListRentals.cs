using System;
using System.IO;
using System.Threading.Tasks;
using BlueBoxRental.RentalServices.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlueBoxRental.RentalServices.Services
{
    public static class ListRentals
    {
        [FunctionName("ListRentals")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("ListRentals function processed a request.");

                using (SakilaContext context = new SakilaContext())
                {
                    return new OkObjectResult(await context.Rental.ToListAsync());
                }
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    $"We apologize but something went wrong on our end.Exception:{ex.Message}");
            }
            finally
            {
                log.LogInformation("ListRentals function has finished processing a request.");
            }
        }
    }
}
