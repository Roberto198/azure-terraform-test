using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Client.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Client
{
    public class GetVehicles
    {
        [FunctionName("GetVehicles")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "vehicles")] HttpRequest req,
            ILogger log)
        {
            // log.LogInformation("C# HTTP trigger function processed a request.");

            // string name = req.Query["name"];

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            // string responseMessage = string.IsNullOrEmpty(name)
            //     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //     : $"Hello, {name}. This HTTP triggered function executed successfully.";

            String str = null;
            str = Environment.GetEnvironmentVariable("sqldb_connection");

            if(str == null)
            {
                return new OkObjectResult("no string");
            } else
            {
                return new OkObjectResult(str);
            }

            // var str = Environment.GetEnvironmentVariable("sqldb_connection");
            // using (SqlConnection conn = new SqlConnection(str))
            // {
            //     conn.Open();
            //     var text = "UPDATE SalesLT.SalesOrderHeader " +
            //             "SET [Status] = 5  WHERE ShipDate < GetDate();";

            //     using (SqlCommand cmd = new SqlCommand(text, conn))
            //     {
            //         // Execute the command and log the # rows affected.
            //         var rows = await cmd.ExecuteNonQueryAsync();
            //         log.LogInformation($"{rows} rows were updated");
            //     }
            // }




            // //Van detail mock data
            // Van response = new Van() {
            //     colour = "white",
            //     size = "tiny",
            //     numberPlate = "xh04 rhf"
            // };
            


            // return new OkObjectResult(response);
        }
    }
}
