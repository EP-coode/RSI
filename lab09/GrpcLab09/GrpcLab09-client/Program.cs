using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcLab09_client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting gRPC Client");
            var chanel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Kociarnia.KociarniaClient(chanel);
            Console.WriteLine("Enter the name: ");
            string str = Console.ReadLine();
            int val = 21;
            var reply = await client.DodajKotkaAsync(new Kotek()
            {
                Id = 1,
                Nazwa = "Kitek",
                Waga = 5,
            });
            Console.WriteLine($"From server: {reply.Msg}");
            reply = await client.DodajKotkaAsync(new Kotek()
            {
                Id = 2,
                Nazwa = "Tygrys",
                Waga = 6,
            });
            Console.WriteLine($"From server: {reply.Msg}");

            reply = await client.DodajKotkaAsync(new Kotek()
            {
                Id = 2,
                Nazwa = "Tygrys",
                Waga = 6,
            });
            Console.WriteLine($"From server: {reply.Msg}");


            ListaKotow l = await client.PodajKotkiAsync(new ParametryWyszukiwaniaKotkow());

            foreach(var kotek in l.Kotki)
            {
                Console.WriteLine($"Kot {kotek.Nazwa} ma wagę, {kotek.Waga}");
            }

            Console.ReadKey();
            chanel.ShutdownAsync().Wait();
        }
    }
}
