using System;
using DockerAppSetting;
using Microsoft.Extensions.Configuration;

namespace DockerGateWay.Configurations
{
    public class AppSetting
    {
        public static IConfiguration Configuration;
        public AppSetting(){}

        public static AppSetting Inst { get; } = new AppSetting();

        public string[] AllowedOrigins => Configuration.GetSection("AllowedOrigins").Get<string[]>();

        private ApiSetting _ApiSetting;
        public ApiSetting ApiSetting
        {
            get
            {
                if (_ApiSetting == null)
                {
                    _ApiSetting = new ApiSetting
                    {
                        Ip = string.IsNullOrWhiteSpace(Configuration["ip"]) ? "127.0.0.1" : Configuration["ip"],
                        Port = string.IsNullOrWhiteSpace(Configuration["port"]) ? 5000 : Convert.ToInt32(Configuration["port"]),
                        Tags = string.IsNullOrWhiteSpace(Configuration["weight"]) ? 1 : Convert.ToInt32(Configuration["weight"]),
                        Index = string.IsNullOrWhiteSpace(Configuration["index"]) ? 0 : Convert.ToInt32(Configuration["index"])
                    };
                }
                return _ApiSetting;
            }
        }

        private ConsulSetting _ConsulSetting;

        public ConsulSetting ConsulSetting
        {
            get
            {
                if (_ConsulSetting == null)
                {
                    _ConsulSetting = new ConsulSetting
                    {
                        Name = Configuration["Consul:Name"],
                        Ip = string.IsNullOrWhiteSpace(Configuration["Consul:IP"]) ? "127.0.0.1" : Configuration["Consul:IP"],
                        Port = string.IsNullOrWhiteSpace(Configuration["Consul:Port"]) ? 8500 : Convert.ToInt32(Configuration["Consul:Port"]),
                        Interval = string.IsNullOrWhiteSpace(Configuration["Consul:Interval"]) ? 12 : Convert.ToInt32(Configuration["Consul:Interval"]),
                        Timeout = string.IsNullOrWhiteSpace(Configuration["Consul:Timeout"]) ? 5 : Convert.ToInt32(Configuration["Consul:Timeout"]),
                        DeregisterInterval = string.IsNullOrWhiteSpace(Configuration["Consul:DeregisterInterval"]) ? 12 : Convert.ToInt32(Configuration["Consul:DeregisterInterval"])
                    };
                }
                return _ConsulSetting;
            }
        }

    }
}
