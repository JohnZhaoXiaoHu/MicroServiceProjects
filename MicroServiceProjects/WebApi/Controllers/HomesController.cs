using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        // GET: api/<HomesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "valuess";
        }

        // POST api/<HomesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
