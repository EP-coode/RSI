using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klient.CarsServiceReference;

namespace Klient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carsClient = new RestServiceClient();

            var cars = carsClient.getAllJson();

            Console.WriteLine("END");
        }
    }
}
