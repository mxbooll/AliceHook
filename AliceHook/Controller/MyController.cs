using Microsoft.AspNetCore.Mvc;

namespace AliceHook.Controller
{
    [ApiController]
    [Route("/")]
    public class MyController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "It works!";
        }
    }
}