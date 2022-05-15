using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfServiceContract1;

namespace WcfHost
{
    internal class Program
    {

        static void Main(string[] args)
        {
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
