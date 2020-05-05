
using AliceHook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace AliceHook.Controller
{
    [ApiController]
    [Route("/")]
    public class AliceController : ControllerBase
    {
        private static readonly JsonSerializerSettings ConverterSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        [HttpGet]
        public string Get()
        {
            return "It works!";
        }

        [HttpPost]
        public Task Post()
        {
            using var reader = new StreamReader(Request.Body);
            var body = reader.ReadToEnd();

            var aliceRequest = JsonConvert.DeserializeObject<AliceRequest>(body, ConverterSettings);
            var aliceResponce = new AliceResponce(aliceRequest)
            {
                Response = { Text = "Привет"}
            };

            var stringResponce = JsonConvert.SerializeObject(aliceResponce, ConverterSettings);
            return Response.WriteAsync(stringResponce);
        }
    }
}