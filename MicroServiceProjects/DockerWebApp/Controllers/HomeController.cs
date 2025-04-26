using System;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using DataModel;
using DockerWebApp.Models;

namespace DockerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var user = InvokeHttp();
            ViewData["User"] = user.Result;
            return View();
        }

        private async Task<ViewModel> InvokeHttp()
        {
            try
            {
                //ConsulClient consulClient = new ConsulClient(c =>
                //{
                //    c.Address = new Uri($"http://{_configuration["Consul:IP"]}:{_configuration["Consul:Port"]}/");
                //    c.Datacenter = "dc1";
                //});

                //var serviceResult = consulClient.Health.Service($"{_configuration["Consul:Name"]}", string.Empty, true);
                //var services = new string[serviceResult.Result.Response.Length];

                //int i = 0;
                //foreach (var service in serviceResult.Result.Response)
                //{
                //    services[i++] = $"{service.Service.Address}:{service.Service.Port}";
                //}

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:6299");
                //client.BaseAddress = new Uri("http://localhost:5000");


                HttpResponseMessage response = await client.GetAsync("api/users");
                if (response.IsSuccessStatusCode)
                {
                    var returnVal = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<User>>(returnVal);
                    return new ViewModel
                    {
                        HasSuccess = true,
                        Users = users,
                        Error = null
                    };
                }
                else
                {
                    if ((int)response.StatusCode == 666)
                    {
                        var returnVal = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<ErrorModel>(returnVal);
                        return new ViewModel
                        {
                            HasSuccess = false,
                            Users = null,
                            Error = error
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                return new ViewModel
                {
                    HasSuccess = false,
                    Users = null,
                    Error = new ErrorModel
                    {
                        Code = "40699",
                        Message = $"AddressNotAvailable: {ex.Message}"
                    }
                };
            }

            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
