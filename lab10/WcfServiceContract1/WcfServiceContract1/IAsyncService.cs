using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract1
{
    [ServiceContract]
    public interface IAsyncService
    {
        [OperationContract(IsOneWay = true)]
        void Fun1(String s1);

        [OperationContract]
        void Fun2(String s2);
    }
}
