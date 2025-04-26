using System;
using EmailNoticeService.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EmailNoticeService.Controllers
{
    [Route("api/notice")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        public IConfiguration Configuration = null;

        public NoticeController(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        [HttpPost]
        [Route("email")]
        public IActionResult Notice()
        {
            Console.WriteLine($"Email Notice {Configuration["port"]}");
            var bytes = new byte[10240];
            var i = Request.Body.ReadAsync(bytes, 0, bytes.Length);
            var message = System.Text.Encoding.UTF8.GetString(bytes).Trim('\0');

          
            EmailSettings settings = new EmailSettings()
            {
                To = Configuration["Email:To"],
                From = Configuration["Email:From"],
                Subject = Configuration["Email:Subject"]
            };

            if (string.IsNullOrWhiteSpace(message))
            {
                var content = new Content {
                    Body = settings.Subject
                };

                message = JsonConvert.SerializeObject(content);
            }
    
            EmailHelper.SendHealthEmail(settings, message);

            return Ok();
        }
    }
}
