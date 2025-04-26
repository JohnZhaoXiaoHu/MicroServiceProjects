using EasyNetQ;
using System;

namespace RabbitMQTestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscribe();
            Console.ReadKey();
        }

        public async static void Subscribe()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            await bus.PubSub.SubscribeAsync<string>("my_subscription_id", msg => Console.WriteLine(msg));
            Console.WriteLine("Hello World!");
        }
    }
}
