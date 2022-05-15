using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfProxyClient.ComplexCalcServiceRef;
using WcfProxyClient.AsyncServiceRef;
using WcfProxyClient.SuperCalcRef;
using System.Threading;
using System.ServiceModel;

namespace WcfProxyClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexCalcClient client = new ComplexCalcClient();
            ComplexNum cnum1 = new ComplexNum();
            cnum1.real = 1.2;
            cnum1.imag = 3.4;
            ComplexNum cnum2 = new ComplexNum();
            cnum1.real = 5.6;
            cnum1.imag = 7.8;
            Console.WriteLine("\nCLIENT1 - START");
            Console.WriteLine("...calling addCnum(...)");
            ComplexNum result1 = client.addCNum(cnum1, cnum2);
            Console.WriteLine("calling addCnum(...) = ({0},{1})", result1.real, result1.imag);
            //Console.WriteLine("--> Press ENTER to continue");
            //Console.ReadLine();

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

            client2.Close();
            Console.WriteLine("CLIENT 2 - STOP");


            Console.WriteLine("CLIENT3 - START (Callbacks)");
            SuperCalcCallback callback = new SuperCalcCallback();
            InstanceContext instanceContext = new InstanceContext(callback);
            SuperCalcClient client3 = new SuperCalcClient(instanceContext);

            double value1 = 10;
            Console.WriteLine("...call of Factorial({0})...", value1);
            client3.Factorial(value1);

            int value2 = 2;
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
