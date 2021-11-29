using System;
using System.Text.Json;
using Model;
using SimpleMessaging;

namespace Sender
{
    class Producer
    {
        static void Main(string[] args)
        {
            using (var channel = new DataTypeChannelProducer<Greeting>(greeting => JsonSerializer.Serialize(greeting)))
            {
                var greeting = new Greeting();
                greeting.Salutation = "Hello World!";
                channel.Send(greeting);
                Console.WriteLine("Sent message {0}", greeting.Salutation);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}