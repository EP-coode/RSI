using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Klient
{
    internal class Program
    {
        static void Main(string[] args)
        {
           RestServiceClient restServiceClient = new RestServiceClient();

            restServiceClient.Close();


        }
    }
}
