using System;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;

namespace publisherMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var publisher = new PublisherSocket())
            {
                publisher.Bind("tcp://*:5556");

                int i = 0;

                while(true)
                {
                    publisher
                        .SendMoreFrame("A") //Topic
                        .SendFrame(i.ToString()); //Message

                    i++;

                    Thread.Sleep(10);
                }
            }
        }
    }
}
