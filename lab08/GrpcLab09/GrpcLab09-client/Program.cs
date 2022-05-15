using System;
using System.Net;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcLab09_client
{
    class MyData
    {
        public static void info()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("Ernest Przybył 256480");
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(System.Environment.OSVersion.VersionString);
            Console.WriteLine(Environment.Version);
            Console.WriteLine(Dns.GetHostByName(Dns.GetHostName()).AddressList[2].ToString());
        }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MyData.info();
            Console.WriteLine("Starting gRPC Client");
            var chanel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Kociarnia.KociarniaClient(chanel);

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
                Waga = 6.5,
            });
            Console.WriteLine($"From server: {reply.Msg}");

            var kotKajtek = new Kotek()
            {
                Id = 3,
                Nazwa = "Kajtek",
                Waga = 6.3,
            };

            reply = await client.DodajKotkaAsync(kotKajtek);
            Console.WriteLine($"From server: {reply.Msg}");


            ListaKotow l = await client.PodajKotkiAsync(new ParametryWyszukiwaniaKotkow());
            Console.WriteLine("-----------------lista kotków ---------------:");

            foreach (var kotek in l.Kotki)
            {
                Console.WriteLine($"Kot {kotek.Nazwa} ma wagę, {kotek.Waga}");
            }

            await client.UsunKotkaAsync(kotKajtek);
            await client.EdytujKotkaAsync(new Kotek()
            {
                Id = 1,
                Nazwa = "Kitek",
                Waga = 10.5
            });

            Console.WriteLine("-----------------Po usunięciu kajtka i edycji kitka ---------------:");
            l = await client.PodajKotkiAsync(new ParametryWyszukiwaniaKotkow());

            foreach (var kotek in l.Kotki)
            {
                Console.WriteLine($"Kot {kotek.Nazwa} ma wagę, {kotek.Waga}");
            }

            Console.ReadKey();
            chanel.ShutdownAsync().Wait();
        }
    }
}
