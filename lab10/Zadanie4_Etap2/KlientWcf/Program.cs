using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using KlientWcf.KotkiServiceRef;

namespace KlientWcf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KotkiCallbackHandler callback = new KotkiCallbackHandler();
            InstanceContext instanceContext = new InstanceContext(callback);
            KotkiServiceClient client = new KotkiServiceClient(instanceContext);


            Dictionary<int, Action> actions = new Dictionary<int, Action>()
            {
                { 1, () => { client.GetKotki(); } },
                { 2, () => { client.GetKotkiByGender(); } },
                { 3, () => { } },
                { 4, () => { } },
                { 5, () => { } },
            };

            while (true)
            {
                PrintActions();
                int selectedAction;
                int.TryParse(Console.ReadLine(), out selectedAction);

                if (actions.ContainsKey(selectedAction))
                {
                    actions[selectedAction]();
                    Console.WriteLine("Poczekaj na wynik...");
                }
            }
        }

        static void PrintActions()
        {
            Console.WriteLine("Wybierz akcje: ");
            Console.WriteLine("1. Podaj wszyskie koty");
            Console.WriteLine("2. Podaj wszyskie kotki");
            Console.WriteLine("3. Podaj wszyskie kocury");
            Console.WriteLine("4. Dodaj kota");
            Console.WriteLine("5. Usun kota");
        }
    }
}
