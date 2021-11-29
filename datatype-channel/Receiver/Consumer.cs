﻿using System;
using System.Text.Json;
using Model;
using SimpleMessaging;

namespace Sender
{
    class Consumer
    {
        static void Main(string[] args)
        {
            using (var channel = new DataTypeChannelConsumer<Greeting>(messageBody => JsonSerializer.Deserialize<Greeting>(messageBody)))
            {
                var greeting = channel.Receive();
                if (greeting != null)
                    Console.WriteLine("Received message {0}", greeting.Salutation);
                else
                   Console.WriteLine("Did not receive message"); 
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}