using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace TodoDemoFunction
{
    public static class CreateToDo
    {
        [FunctionName("CreateToDo")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function,"post", Route = null)]Microsoft.AspNetCore.Http.HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<ToDoItem>(requestBody);

            // Add your logic to save the ToDo item to a database

            return new OkObjectResult(input);
        }


    }
    public class ToDoItem
    {
        public string Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
