using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;

namespace IBASProductionFunc
{
    public static class IBASProdTrigger
    {
        [FunctionName("IBASProdTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName: "IBasSupportDB", containerName: "production", Connection = "CosmosDbConnectionString")] IAsyncCollector<dynamic> documentsOut,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            if (!string.IsNullOrEmpty(data?.lineID?.ToString()))
            {
                log.LogInformation("Storing document in database ...");
                
                // Add a JSON document to the output container. 
                await documentsOut.AddAsync(new
                {
                    id = System.Guid.NewGuid().ToString(),
                    line = data.lineID,
                    model = data.model,
                    status = data.status,
                    serial = data.serial
                });
            }

            string responseMessage = string.IsNullOrEmpty(data?.lineID?.ToString())
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {data.lineID}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
