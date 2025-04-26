using EasyNetQ;
using Messages;
using System;
using System.Text;

namespace Subscriber2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<TextMessage>("you", ReceiveMessage);
                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
            Console.ReadKey();
        }

        static void ReceiveMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Got message: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(textMessage.Text);
            Console.OutputEncoding = Encoding.UTF8;
            Console.ResetColor();
        }
    }
}
