using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfServiceContract1;

namespace WcfHost
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
            WSHttpBinding binding = new WSHttpBinding();
            WSDualHttpBinding binding2 = new WSDualHttpBinding();
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            Uri baseAddres1 = new Uri("http://localhost:10000/ComplexCalc");
            ServiceHost myHost = new ServiceHost(typeof(ComplexCalcService), baseAddres1);
            ServiceEndpoint endpoint = myHost.AddServiceEndpoint(typeof(IComplexCalc), binding, "endpoint");
            myHost.Description.Behaviors.Add(smb);

            Uri baseAddres2 = new Uri("http://localhost:10001/AsyncService");
            ServiceHost myHost2 = new ServiceHost(typeof(AsyncService), baseAddres2);
            ServiceEndpoint endpoint2 = myHost2.AddServiceEndpoint(typeof(IAsyncService), binding, "endpoint2");
            myHost2.Description.Behaviors.Add(smb);

            Uri baseAddres3 = new Uri("http://localhost:10003/SuperCalc");
            ServiceHost myHost3 = new ServiceHost(typeof(MySuperCalc), baseAddres3);
            ServiceEndpoint endpoint3 = myHost3.AddServiceEndpoint(typeof(ISuperCalc), binding2, "endpoint3");
            myHost3.Description.Behaviors.Add(smb);

            try
            {
                myHost.Open();
                Console.WriteLine("--> ComplexCalculator is running");
                myHost2.Open();
                Console.WriteLine("--> AsyncService is running");
                myHost3.Open();
                Console.WriteLine("--> SuperCalc is running");

                Console.WriteLine("--> Press <ENTER> to stop\n");
                Console.ReadLine();

                myHost.Close();
                Console.WriteLine("--> ComplexCalculator finished");
                myHost2.Close();
                Console.WriteLine("--> AsyncService finished");
                myHost3.Close();
                Console.WriteLine("--> SuperCalc finished");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Exception occured: {0}", ce.Message);
                myHost.Abort();
                myHost2.Abort();
                myHost3.Abort();
            }
        }
    }
}
