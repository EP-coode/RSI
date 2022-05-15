using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfServiceContract1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MySuperCalc : ISuperCalc
    {
        double result;
        ISuperCalcCalback calcCalback = null;

        public MySuperCalc()
        {
            calcCalback = OperationContext.Current.GetCallbackChannel<ISuperCalcCalback>();
        }

        public void DoSomething(int sec)
        {
            Console.WriteLine("...Called DoSmething({0})", sec);
            if (sec > 2 & sec < 10)
                Thread.Sleep(sec * 1000);
            else
                Thread.Sleep(3000);

            calcCalback.DoSomethingResult("Calculations lasted + " + sec + " second(s)");
        }

        public void Factorial(double n)
        {
            Console.WriteLine("...called Factorial({0})", n);
            Thread.Sleep(1000);
            result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            calcCalback.FactorialResult(result);
        }
    }
}
