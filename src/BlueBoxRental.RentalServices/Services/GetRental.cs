using System;
using System.IO;
using System.Linq;
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
    public static class GetRental
    {
        [FunctionName("GetRental")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get",  Route = "GetRental/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            try
            {
                log.LogInformation("GetRental function processed a request.");

                using (SakilaContext context = new SakilaContext())
                {
                    return new OkObjectResult(await context.Rental.Where(r=>r.RentalId == id).SingleOrDefaultAsync());
                }
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    $"We apologize but something went wrong on our end.Exception:{ex.Message}");
            }
            finally
            {
                log.LogInformation("GetRental function has finished processing a request.");
            }
        }
    }
}
