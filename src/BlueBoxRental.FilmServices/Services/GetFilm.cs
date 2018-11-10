using System.Linq;
using System.Threading.Tasks;
using BlueBoxRental.FilmServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlueBoxRental.FilmServices.Services
{
    public static class GetFilm
    {
        [FunctionName("GetFilm")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetFilm/{id}")] HttpRequest req,int id,
            ILogger log)
        {
            try
            {
                log.LogInformation("GetFilm function processed a request.");

                using (SakilaContext context = new SakilaContext())
                {
                    return new OkObjectResult(await context.Film.Where(f=>f.FilmId == id).SingleOrDefaultAsync());
                }
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    $"We apologize but something went wrong on our end.Exception:{ex.Message}");
            }
            finally
            {
                log.LogInformation("GetFilm function has finished processing a request.");
            }
        }
    }
}
