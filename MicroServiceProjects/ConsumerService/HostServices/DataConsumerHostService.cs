using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data.Common;
using System.Text;

namespace ConsumerService.HostServices
{
    public class DataConsumerHostService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory();

            factory.HostName = "localhost";
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";

            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, data) =>
            {
                //3.1、获取数据
                var bytes = data.Body;

                //3.2、二进制转换
                var stringData = Encoding.UTF8.GetString(bytes.ToArray());

                //3.3、反序列化
                var dataDTO = JsonConvert.DeserializeObject<string>(stringData);

                //3.4、存储数据

                Console.WriteLine(dataDTO);
            };


            channel.BasicConsume("", true, consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StopAsync");

            return Task.CompletedTask;
        }
    }
}
