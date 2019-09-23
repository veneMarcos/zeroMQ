using System;
using NetMQ;
using NetMQ.Sockets;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5556");
                var msg = server.ReceiveFrameString();
                Console.WriteLine($"From client {msg}");
                server.SendFrame("World");
            }
        }
    }
}
