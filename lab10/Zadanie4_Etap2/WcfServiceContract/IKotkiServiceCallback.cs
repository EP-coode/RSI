using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceContract
{
    public interface IKotkiServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void AddKotekResult(ICollection<Kotek> kotki);

        [OperationContract(IsOneWay = true)]
        void GetKotkiByPlec(ICollection<Kotek> kotki);

        [OperationContract(IsOneWay = true)]
        void GetKotkiResult(ICollection<Kotek> kotki);

        [OperationContract(IsOneWay = true)]
        void DeleteKotekResult(Kotek usunietyKotek);
    }
}
