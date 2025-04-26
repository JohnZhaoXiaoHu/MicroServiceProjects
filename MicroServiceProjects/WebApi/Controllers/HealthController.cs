using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("~/api/health/check")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
