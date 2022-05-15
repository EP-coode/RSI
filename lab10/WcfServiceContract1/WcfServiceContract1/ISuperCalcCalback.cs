using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract1
{
    public interface ISuperCalcCalback
    {
        [OperationContract(IsOneWay = true)]
        void FactorialResult(double result);

        [OperationContract(IsOneWay = true)]
        void DoSomethingResult(string result);
    }
}
