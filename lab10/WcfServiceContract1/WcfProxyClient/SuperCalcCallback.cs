using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WcfProxyClient.SuperCalcRef;

namespace WcfProxyClient
{
    public class SuperCalcCallback : ISuperCalcCallback
    {
        public void DoSomethingResult(string result)
        {
            Console.WriteLine(" Factorial = {0}", result);
        }

        public void FactorialResult(double result)
        {
            Console.WriteLine(" Calculations = {0}", result);
        }
    }
}
