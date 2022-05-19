using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract1
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class ComplexCalcService : IComplexCalc
    {
        public ComplexNum addCNum(ComplexNum n1, ComplexNum n2)
        {
            Console.WriteLine("...called addCNum(...)");
            return new ComplexNum(n1.real + n2.real, n1.imag + n2.imag);
        }

        public ComplexNum multiplyCnum(ComplexNum n1, ComplexNum n2)
        {
            double real = n1.real * n2.real - n1.imag * n2.imag;
            double imag = n1.imag * n2.real + n1.real * n2.imag;
            return new ComplexNum(real, imag);
        }
    }
}
