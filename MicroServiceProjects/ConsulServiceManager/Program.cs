using Consul;
using System;
using System.Collections.Generic;

namespace ConsulServiceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterConsul();
            //FindServices();

            Console.WriteLine("OKOK");
            Console.ReadLine();

        }

        private static void FindServices()
        {
            ConsulClient consulClient = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");

                c.Datacenter = "dc1";
            });

            //var result = consulClient.Agent.Services().Result.Response;
            //foreach (var service in result)
            //{
            //    Console.WriteLine(service.Key);
            //    Console.WriteLine($"IP地址：{service.Value.Address}-端口:{service.Value.Port}");
            //    Console.WriteLine("===============================");
            //}
            var healthCheck = consulClient.Health.Checks("LoginService");
            var healthChecks = healthCheck.Result.Response;
            List<HealthCheck> healthCheckList = new List<HealthCheck>();
            foreach (var health in healthChecks)
            {
                healthCheckList.Add(health);
            }

            var serviceResult = consulClient.Health.Service("LoginService", string.Empty, true);
            var services = new string[serviceResult.Result.Response.Length];

            int i = 0;
            foreach (var service in serviceResult.Result.Response)
            {
                services[i++] = $"{service.Service.Address}:{service.Service.Port}";
                Console.WriteLine($"{service.Service.Address}:{service.Service.Port}");
            }
        }

        public static void RegisterConsul()
        {
            var consulClient = new ConsulClient(x =>
            {
                x.Address = new Uri($"http://127.0.0.1:8500");
                x.Datacenter = "dc1";
            });

            string ip = "127.0.0.1" ;
            int port =  5726 ;
            int weight = 1;


            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                ID = "Service_LoginService_1",
                Name = "LoginService",
                Address = ip,
                Port = port,
                Tags = new[] { weight.ToString() },
                Check = new AgentServiceCheck
                {
                    Interval = TimeSpan.FromSeconds(12),
                    HTTP = $"http://{ip}:{port}/api/health/check",
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(12),
                }
            };

            try
            {
                consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Register Service '{registration.Name}:{registration.ID}' Failed, {ex.Message}");
            }
        }
    }
}
