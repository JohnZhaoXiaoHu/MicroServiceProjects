using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace PublisherService.Services
{
    public class DataPublisherService
    {
        private readonly IConnection _connection;
        public DataPublisherService() 
        {
            var factory = new ConnectionFactory();

            factory.HostName = "localhost";
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";

            _connection = factory.CreateConnection();
        }


        public bool Publish<T>(string queueName, T t)
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queueName, false, false, false, null);

            string stringJson = JsonConvert.SerializeObject(t);
            byte[] bytes = Encoding.UTF8.GetBytes(stringJson);

            channel.BasicPublish("", queueName, channel.CreateBasicProperties(), bytes);

            return true;
        }
    }
}
