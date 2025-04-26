using Microsoft.AspNetCore.Mvc;
using System;

namespace DockerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("~/api/health/check")]
        public IActionResult Get()
        {
            Console.WriteLine("This is Health check");
            return Ok();
        }
    }
}
