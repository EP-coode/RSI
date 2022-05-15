using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlientWcf.KotkiServiceRef;

namespace KlientWcf
{
    internal class KotkiCallbackHandler : IKotkiServiceCallback
    {
        public void AddKotekResult(Kotek[] kotki)
        {
            Console.WriteLine("Pomyślnie dodano.");
        }

        public void DeleteKotekResult(Kotek usunietyKotek)
        {
            Console.WriteLine("Usunięto kota: ");
            Console.WriteLine(usunietyKotek);
        }

        public void GetKotkiByPlec(Kotek[] kotki)
        {
            Console.WriteLine("Wynik: ");
            foreach (var kotek in kotki)
                Console.WriteLine(kotek);
        }

        public void GetKotkiResult(Kotek[] kotki)
        {
            Console.WriteLine("Wszyskie koty: ");
            foreach (var kotek in kotki)
                Console.WriteLine(kotek);
        }
    }
}
