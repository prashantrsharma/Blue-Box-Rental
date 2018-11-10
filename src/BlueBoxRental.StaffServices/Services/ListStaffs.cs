using System.IO;
using System.Threading.Tasks;
using BlueBoxRental.StaffServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlueBoxRental.StaffServices.Services
{
    public static class ListStaffs
    {
        [FunctionName("ListStaffs")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get",Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("ListStaffs function processed a request.");
                using (SakilaContext context = new SakilaContext())
                {
                    return new OkObjectResult(await context.Staff.ToListAsync());
                }
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    $"We apologize but something went wrong on our end.Exception:{ex.Message}");
            }
            finally
            {
                log.LogInformation("ListStaffs function has finished processing a request.");
            }
        }
    }
}
