using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RabbitMQCommon;
using Newtonsoft.Json;

namespace RabbitMQWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQController : ControllerBase
    {
        private RabbitMQConfig Config;
        public MQController(IOptions<RabbitMQConfig> option)
        {
            Config = option.Value;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("~/api/mq/message")]
        public void Post([FromBody] Message message)
        {
            
            RabbitMQHelper.Publish(Config.MQSetting, Config.HostMachineInfo, JsonConvert.SerializeObject(message));
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
