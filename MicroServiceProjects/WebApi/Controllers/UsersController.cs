using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IConfiguration Configuration = null;

        private List<User> _Users = new List<User>();
        public UsersController(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            for (int i = 0; i < 5; i++)
            {
                _Users.Add(new User
                {
                    Id = i.ToString(),
                    Name = "User " + i,
                    Age = 20 + i,
                    Sex = (i % 2 == 0) ? "Male" : "Female",
                    BirthDay = DateTime.Now.AddYears(-(20 + i)),
                    Timestamp = DateTime.Now,
                    Host = $"{Configuration["ip"]}:{Configuration["port"]}"
                });
            }
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            Console.WriteLine($"This is {Configuration["ip"]}:{Configuration["port"]} request");
            return _Users;
        }

        // GET api/<UserController>/5
        [HttpGet("~/api/user/{id}")]
        public User Get(string id)
        {
            var user = _Users.Find(u => u.Id.ToLower() == id.ToLower());
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
