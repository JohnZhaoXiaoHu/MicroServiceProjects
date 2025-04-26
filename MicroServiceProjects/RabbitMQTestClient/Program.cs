using EasyNetQ;
using System;

namespace RabbitMQTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Publish();
            Console.ReadKey();
        }

        public async static void Publish()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            await bus.PubSub.PublishAsync<string>("aaaa");
            Console.WriteLine("Hello World!");
        }
    }
}
