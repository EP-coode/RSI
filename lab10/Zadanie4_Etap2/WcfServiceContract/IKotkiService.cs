using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfServiceContract
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IKotkiServiceCallback))]
    public interface IKotkiService
    {
        [OperationContract(IsOneWay = true)]
        void DodajKotka(Kotek k);

        [OperationContract(IsOneWay = true)]
        void GetKotki();

        [OperationContract(IsOneWay = true)]
        void GetKotkiByGender(Plec p);

        [OperationContract(IsOneWay = true)]
        void RemoveKotek(int idKotka);

    }
}
