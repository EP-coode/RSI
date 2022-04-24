using GrpcLab09;
using System.Collections.Generic;

namespace GrpcLab09.Services
{
    public interface IKotkiService
    {
        public OperationStatusResponse DodajKotka(Kotek k);
        public List<Kotek> PodajKotki();
        public void UsunKotka(Kotek k);
        public OperationStatusResponse EdytujKotka(Kotek k);
    }
}
