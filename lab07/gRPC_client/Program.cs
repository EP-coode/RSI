using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace gRPC_client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting gRPC Client");
            var chanel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcService.GrpcServiceClient(chanel);
            Console.WriteLine("Enter the name: ");
            string str = Console.ReadLine();
            int val = 21;
            var reply = await client.GrpcProcAsync(new GrpcRequest(){
                Name = str,
                Age = val,
            });
            Console.WriteLine($"From server: {reply.Message}\n" +
                $"From server: {val} years = {reply.Days} days\n" +
                $"Press any key to exit...");
            Console.ReadKey();
            chanel.ShutdownAsync().Wait();
        }
    }
}
