using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceContract1
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISuperCalcCalback))]
    public interface ISuperCalc
    {
        [OperationContract(IsOneWay = true)]
        void Factorial(double n);
        [OperationContract(IsOneWay = true)]
        void DoSomething(int sec);
    }
}
