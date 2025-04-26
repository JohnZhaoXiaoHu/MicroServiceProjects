using System;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microservices.Extensions
{
    public static class ConsulHelper
    {
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IConfiguration configuration, IHostApplicationLifetime lifetime)
        {
            string ip = string.IsNullOrWhiteSpace(configuration["IP"])
                   ? configuration["Consul:IP"]
                   : configuration["IP"];

            int port = string.IsNullOrWhiteSpace(configuration["Port"])
                       ? Convert.ToInt32(configuration["Consul:Port"])
                       : Convert.ToInt32(configuration["Port"]);

            string Address = string.IsNullOrWhiteSpace(configuration["Consul:Address"]) ? $"http://{ip}:8500" : configuration["Consul:Address"];

            string tag = string.IsNullOrWhiteSpace(configuration["Tag"]) ? "1" : configuration["Tag"];
            string dc = string.IsNullOrWhiteSpace(configuration["Consul:DataCenter"]) ? "dc1" : configuration["Consul:DataCenter"];
            string name = string.IsNullOrWhiteSpace(configuration["Consul:Name"]) ? $"Service_{Guid.NewGuid().ToString()}" : configuration["Consul:Name"];
            string healthCheck = string.IsNullOrWhiteSpace(configuration["Consul:HealthCheck"]) ? "/api/health/check" : configuration["Consul:HealthCheck"];

            int interval = string.IsNullOrWhiteSpace(configuration["Consul:Interval"]) ? 12 : Convert.ToInt32(configuration["Consul:Interval"]);
            int timeout = string.IsNullOrWhiteSpace(configuration["Consul:Timeout"]) ? 5 : Convert.ToInt32(configuration["Consul:Timeout"]);
            int deregisterInterval = string.IsNullOrWhiteSpace(configuration["Consul:DeregisterInterval"]) ? 12 : Convert.ToInt32(configuration["Consul:DeregisterInterval"]);

            int waitTimeout = string.IsNullOrWhiteSpace(configuration["Consul:WaitTimeout"]) ? 0 : Convert.ToInt32(configuration["Consul:WaitTimeout"]);

            string index = string.IsNullOrWhiteSpace(configuration["index"]) ? "0" : configuration["index"];

            Console.WriteLine("************************************************");
            Console.WriteLine($"           IP : {ip}");
            Console.WriteLine($"         Port : {port}");
            Console.WriteLine($"ConsulAddress : {Address}");
            Console.WriteLine($"          Tag : {tag}");
            Console.WriteLine($"   DataCenter : {dc}");
            Console.WriteLine($"  ServiceName : {name}");
            Console.WriteLine($"  HealthCheck : {healthCheck}");
            Console.WriteLine("************************************************");

            var consulClient = new ConsulClient(c =>
            {
                c.Address = new Uri($"{Address}");
                c.Datacenter = $"{dc}";
            });

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                ID = $"Service_{name}_{Guid.NewGuid().ToString()}",
                Name = name,
                Address = ip,
                Port = port,
                Tags = new[] { tag },
                Check = new AgentServiceCheck
                {
                    Interval = TimeSpan.FromSeconds(interval),
                    HTTP = $"http://{ip}:{port}{healthCheck}",
                    Timeout = TimeSpan.FromSeconds(timeout),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(deregisterInterval),
                }
            };

            try
            {
                Console.WriteLine($"[INFO]: App service '{registration.ID}' is Starting, Register Service: '{registration.Name}:{registration.ID}' to consul");
                if (waitTimeout != 0)
                {
                    //服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
                    consulClient.Agent.ServiceRegister(registration).Wait(waitTimeout);
                }
                else
                {
                    //服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
                    consulClient.Agent.ServiceRegister(registration).Wait();
                }

                lifetime.ApplicationStopping.Register(() =>
                {
                    Console.WriteLine($"[INFO]: App service '{registration.ID}' is Stopping, Deregister service '{registration.Name}:{registration.ID}' from consul");
                    consulClient.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: Register Service '{registration.Name}:{registration.ID}' Failed, ErrorMessage: {ex.ToString()}");
            }

            return app;
        }
    }
}
