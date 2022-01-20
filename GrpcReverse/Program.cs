using Grpc.Core;
using GrpcReverse.Services;
using System;
using System.Threading.Tasks;

namespace GrpcReverse
{
    class Program
    {
        private const string Host = "localhost";
        private const int Port = 5001;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var server = new Server();
            server.Services.Add(Reverse.BindService(new ReverseService()));
            server.Ports.Add(new ServerPort(Host, Port, ServerCredentials.Insecure));
            server.Start();

            Console.WriteLine($"The service is ready at {Host}, on port {Port}");
            Console.WriteLine("Press any key to stop the service...");
            Console.ReadKey();

            await server.ShutdownAsync();
        }
    }
}
