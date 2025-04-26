using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DataModel;

namespace DockerWebApi.Controllers
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

        [HttpGet]
        [Route("~/api/users")]
        public IEnumerable<User> Get()
        {
            Console.WriteLine($"This is {Configuration["ip"]}:{Configuration["port"]} request");
            return _Users;
        }

        [HttpGet]
        [Route("~/api/users/{id}")]
        public User Get(string id)
        {
            var user = _Users.Find(u => u.Id.ToLower() == id.ToLower());
            return user;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
