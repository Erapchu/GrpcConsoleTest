using Grpc.Core;
using Grpc.Net.Client;
using System;

namespace GrpcReverseClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serverAddress = "http://localhost:5001";

            // Using old Grpc.Core instead of Grpc.Net.Client
            //var c = new Channel(serverAddress, ChannelCredentials.Insecure);
            using var channel = GrpcChannel.ForAddress(serverAddress, new GrpcChannelOptions() { Credentials = ChannelCredentials.Insecure });
            var client = new Reverse.ReverseClient(channel);

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Input: ");
                var toReverse = Console.ReadLine();
                var reply = client.ReverseString(new StringRequest() { ToReverse = toReverse });
                Console.WriteLine($"Reversed: {reply.ReversedString}");
            }

            Console.ReadKey();
        }
    }
}
