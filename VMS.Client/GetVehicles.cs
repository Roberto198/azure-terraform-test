using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VMS.Client.Models;

namespace VMS.Client
{
    public class GetVehicles
    {

        private readonly VMSDbContext _context;

        public GetVehicles(VMSDbContext context)
        {
            this._context = context;
        }

        [FunctionName("GetVehicles")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "vehicles")] HttpRequest req,
            ILogger log)
        {


            //_context.



             //var str = Environment.GetEnvironmentVariable("sqldb_connection");
             //using (SqlConnection conn = new SqlConnection(str))
             //{
             //    conn.Open();
             //    var text = "UPDATE SalesLT.SalesOrderHeader " +
             //            "SET [Status] = 5  WHERE ShipDate < GetDate();";

             //    using (SqlCommand cmd = new SqlCommand(text, conn))
             //    {
             //        // Execute the command and log the # rows affected.
             //        var rows = await cmd.ExecuteNonQueryAsync();
             //        log.LogInformation($"{rows} rows were updated");
             //    }
             //}



            //Van detail mock data
            Van response = new Van() {

                VanId = new Guid("9ced95b6 - 6d20 - 4ba6 - 9827 - a59ab70ed02f"),
                RegistrationNumber = "YH12 JGF",
                Colour = "red",
                Size = "small",
                DriverClass = "driverClass"
        };
            


          return new OkObjectResult(response);
        }
    }
}
