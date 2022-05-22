using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfProxyClient.CCalcRef;
using WcfProxyClient.AsyncServiceRef;
using WcfProxyClient.SuperCalcRef;
using System.Threading;
using System.ServiceModel;
using System.Net;

namespace WcfProxyClient
{
    internal class Program
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
                Console.WriteLine(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString());
            }
        }
        static void Main(string[] args)
        {
            MyData.info();
            ComplexCalcClient client = new ComplexCalcClient();
            ComplexNum cnum1 = new ComplexNum();
            Console.WriteLine("Podaj liczbę 1: ");
            Console.WriteLine("r=");
            string input = Console.ReadLine();
            Console.WriteLine("i=");
            cnum1.real = double.Parse(input);
            input = Console.ReadLine();
            cnum1.imag = double.Parse(input);
            ComplexNum cnum2 = new ComplexNum();
            Console.WriteLine("Podaj liczbę 2: ");
            Console.WriteLine("r=");
            input = Console.ReadLine();
            cnum2.real = double.Parse(input);
            Console.WriteLine("i=");
            input = Console.ReadLine();
            cnum2.imag = double.Parse(input);
            Console.WriteLine("\nCLIENT1 - START");

            Console.WriteLine("...calling addCnum(...)");
            ComplexNum result1 = client.addCNum(cnum1, cnum2);
            Console.WriteLine("calling addCnum(...) = ({0},{1})", result1.real, result1.imag);

            Console.WriteLine("...calling multiplyCnum(...)");
            ComplexNum result2 = client.multiplyCnum(cnum1, cnum2);
            Console.WriteLine("calling multiplyCnum(...) = ({0},{1})", result2.real, result2.imag);
            Console.WriteLine("--> Press ENTER to continue");
            Console.ReadLine();

            client.Close();
            Console.WriteLine("CLIENT1 - STOP");

            Console.WriteLine("CLIENT2 - START (Async service)");
            AsyncServiceClient client2 = new AsyncServiceClient();

            Console.WriteLine("...calling Fun 1");
            client2.Fun1("Client2");
            Thread.Sleep(10);
            Console.WriteLine("...contuinue after Fun 1 call");

            Console.WriteLine("...calling Fun 2");
            client2.Fun2("Client2");
            Thread.Sleep(10);
            Console.WriteLine("...continue after Fun 2 call");

            Console.WriteLine("--> Press ENTER to continue");
            Console.ReadLine();

            client2.Close();
            Console.WriteLine("CLIENT 2 - STOP");


            Console.WriteLine("CLIENT3 - START (Callbacks)");
            SuperCalcCallback callback = new SuperCalcCallback();
            InstanceContext instanceContext = new InstanceContext(callback);
            SuperCalcClient client3 = new SuperCalcClient(instanceContext);

            Console.WriteLine("Podaj liczbę do faktoryzowania: ");
            input = Console.ReadLine();
            double value1 = double.Parse(input);
            Console.WriteLine("...call of Factorial({0})...", value1);
            client3.Factorial(value1);

            Console.WriteLine("Podaj czas oczekiwania: ");
            input = Console.ReadLine();
            int value2 = int.Parse(input);
            Console.WriteLine("...call of Do Something...");
            client3.DoSomething(value2);

            value1 = 20;
            Console.WriteLine("...call of Factorial({0})...", value1);
            client3.Factorial(value1);

            Console.WriteLine("--> Client must wait for the results");
            Console.WriteLine("--> Press ENTER after reciving aLL results");

            Console.ReadLine();

            client3.Close();
            Console.WriteLine("CLIENT3 - STOP");
        }
    }
}
