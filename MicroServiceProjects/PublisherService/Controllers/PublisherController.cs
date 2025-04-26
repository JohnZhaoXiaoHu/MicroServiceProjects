using Microsoft.AspNetCore.Mvc;
using PublisherService.Services;

namespace PublisherService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly DataPublisherService _DataPublish;
        public PublisherController(ILogger<PublisherController> logger, DataPublisherService dataPublish)
        {
            _logger = logger;
            _DataPublish = dataPublish;
        }

        [HttpGet]
        public string CreateProduct()
        {
            _DataPublish.Publish<string>("CreateProduct", "");

            return "";
        }
    }
}