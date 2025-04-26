using System.Text;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;

namespace RabbitMQCommon
{
    public class RabbitMQHelper
    {
        public static void Publish(MQSetting mQSetting, HostMachineInfo host, string message)
        {
            var channel = RabbitMQManager.GetChannel(host);
            channel.QueueDeclare(
                queue: mQSetting.QueueName,
                durable: mQSetting.QPersistence,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.ExchangeDeclare(
                exchange: mQSetting.ExchangeName,
                type: "direct",
                durable: mQSetting.EPersistence,
                autoDelete: false,
                arguments: null);

            channel.QueueBind(
                queue: mQSetting.QueueName,
                exchange: mQSetting.ExchangeName,
                routingKey: "",
                arguments: null);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = mQSetting.MPersistence; //标记信息持久化（第一种）
            properties.DeliveryMode = (byte)(mQSetting.MPersistence ? 2 : 1); //1: 非持久化; 2: 持久化 (第二种)

            channel.BasicPublish(
                exchange: mQSetting.ExchangeName,
                routingKey: mQSetting.RoutingKey,
                mandatory: false,
                basicProperties: properties,
                body: Encoding.UTF8.GetBytes(message));
        }

        public static void Subscribe(HostMachineInfo host)
        {
            var channel = RabbitMQManager.GetChannel(host);
            channel.QueueDeclare(
                queue: "MQ_Queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            //var properties = channel.CreateBasicProperties();
            //properties.Persistent = mQSetting.MPersistence; //标记信息持久化（第一种）
            //properties.DeliveryMode = (byte)(mQSetting.MPersistence ? 2 : 1); //1: 非持久化; 2: 持久化 (第二种)

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Receive;

            channel.BasicConsume(
                queue: "MQ_Queue",
                autoAck: true,
                consumerTag: "",
                noLocal: false,
                exclusive: false,
                arguments: null,
                consumer: consumer);
        }

        private static void Receive(object? sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var config = JsonConvert.DeserializeObject<Message>(message);
            Console.WriteLine($"Receiv: {message}");
        }
    }
}