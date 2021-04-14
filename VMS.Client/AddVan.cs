using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VMS.Client.DbModels;

namespace VMS.Client
{
    public class AddVan
    {
        private readonly IVanController _vanController;


        public AddVan(IVanController vanController)
        {
            _vanController = vanController;
        }

        [FunctionName("AddVan")]
        public async Task<IActionResult> Run
            (
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "addVehicle")]
            HttpRequest req,
            ILogger log
            )
        {
            Van newVan;
            try
            {
                string requestBody = String.Empty;
                using (StreamReader streamReader = new StreamReader(req.Body))
                {
                    requestBody = await streamReader.ReadToEndAsync();
                }

                dynamic newVanRequest = JsonConvert.DeserializeObject(requestBody);


                newVan = new Van()
                {

                    VanId = Guid.NewGuid(),
                    RegistrationNumber = newVanRequest.RegistrationNumber,
                    Colour = newVanRequest.Colour,
                    Size = newVanRequest.Size,
                    DriverClass = newVanRequest.DriverClass
                };
                _vanController.AddVanController(newVan);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new OkObjectResult(e.ToString());
            }

            return new OkObjectResult(newVan);
        }
    }
}


