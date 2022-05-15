using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract;

namespace KotkiServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WSDualHttpBinding binding = new WSDualHttpBinding();
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            Uri baseAddres = new Uri("http://localhost:10000/KotkiService");
            ServiceHost myHost = new ServiceHost(typeof(KotkiService), baseAddres);
            ServiceEndpoint endpoint = myHost.AddServiceEndpoint(typeof(IKotkiService), binding, "endpoint");
            myHost.Description.Behaviors.Add(smb);

            try
            {
                myHost.Open();
                Console.WriteLine("--> KotkiService is running");

                Console.WriteLine("PRESS ENTER TO STOP");
                Console.ReadLine();

                myHost.Close();
                Console.WriteLine("--> KotkiService stopped");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Exception occured: {0}", ce.Message);
                myHost.Abort();
            }
        }
    }
}
