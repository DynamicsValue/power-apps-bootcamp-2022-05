using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.PowerPlatform.Dataverse.Client;
using System.Runtime.CompilerServices;
using Microsoft.Xrm.Sdk;

[assembly: InternalsVisibleTo("MyAzureFunctionTests")]
namespace DynamicsValue.AzFunctions
{
    public static class CreateContactFn
    {
        [FunctionName("CreateContactFn")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string firstName = req.Query["firstname"];
            string email = req.Query["email"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            firstName = firstName ?? data?.firstName;
            email = email ?? data?.email;

            string responseMessage = string.IsNullOrEmpty(firstName)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {firstName}. This HTTP triggered function executed successfully.";



            return new OkObjectResult(responseMessage);
        }

        internal static async Task<GenericResult> CreateContact(IOrganizationServiceAsync2 service, string firstName, string email)
        {
            await service.CreateAsync(new Entity("contact") 
            {
                ["firstname"] = firstName,
                ["emailaddress1"] = email
            });

            return GenericResult.Succeed();
        }
    }
}
