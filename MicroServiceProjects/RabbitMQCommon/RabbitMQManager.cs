using RabbitMQ.Client;

namespace RabbitMQCommon
{
    public class RabbitMQManager
    {  
        public static IConnection GetConnection(HostMachineInfo hostMachineInfo )
        {
            var factory = new ConnectionFactory()
            {
                UserName = hostMachineInfo.UserName,
                Password = hostMachineInfo.Password,
            };

            List<AmqpTcpEndpoint> endpoints = new List<AmqpTcpEndpoint>();
            hostMachineInfo.EndPointInfos.ForEach(h => {
                endpoints.Add(new AmqpTcpEndpoint { HostName = h.HostName, Port = h.Port });
            });

            return factory.CreateConnection(endpoints);
        }

        public static IModel GetChannel(HostMachineInfo hostMachineInfo)
        {
            return GetConnection(hostMachineInfo).CreateModel();
        }
    }
}
