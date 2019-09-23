using System;
using NetMQ;
using NetMQ.Sockets;

namespace subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sub = new SubscriberSocket())
            {
                sub.Connect("tcp://127.0.0.1:5556");
                sub.Subscribe("A");

                while(true)
                {
                    var topic = sub.ReceiveFrameString();
                    var msg = sub.ReceiveFrameString();
                    Console.WriteLine($"From publisher: {topic} {msg}");
                }

            }
        }
    }
}
