using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GrpcLab09
{
    class MyData
    {
        public static void info()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("Ernest Przyby³ 256480");
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(System.Environment.OSVersion.VersionString);
            Console.WriteLine(Environment.Version);
            Console.WriteLine(Dns.GetHostByName(Dns.GetHostName()).AddressList[2].ToString());
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            MyData.info();
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
