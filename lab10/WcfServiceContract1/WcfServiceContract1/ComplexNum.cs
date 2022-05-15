using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract1
{
    [DataContract]
    public class ComplexNum
    {
        string description = "Complex number";

        [DataMember]
        public double real;

        [DataMember]
        public double imag;

        [DataMember]
        public string Desc
        {
            get { return description; }
            set { description = value; }
        }

        public ComplexNum(double r, double i)
        {
            real = r;
            imag = i;
        }
    }
}
