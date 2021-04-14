using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VMS.Client.DbModels;
using Microsoft.Extensions.DependencyInjection;
using VMS.Client;


namespace VMS.Client
{


    public class GetVehicles
    {
        private readonly IVanController _vanController;


        public GetVehicles(IVanController vanController)
        {
            _vanController = vanController;
        }

        [FunctionName("GetVehicles")]
        public async Task<IActionResult> Run
            (
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getVehicles")]
            HttpRequest req,
            ILogger log
            )
        {
            Van[] vans;
            try
            {
                vans = _vanController.GetVansController();

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new OkObjectResult(e.ToString());
            }

            return new OkObjectResult(vans);
        }
    }
}
