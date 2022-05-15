using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfServiceContract1
{
    public class AsyncService : IAsyncService
    {
        public void Fun1(string s1)
        {
            Console.WriteLine("...called Fun 1 - start");
            Thread.Sleep(4000);
            Console.WriteLine("..Fun 1 - stop");
        }

        public void Fun2(string s2)
        {
            Console.WriteLine("...called Fun 2 - start");
            Thread.Sleep(2000);
            Console.WriteLine("..Fun 2 - stop");
        }
    }
}
