using GrpcLab09;
using System.Collections.Generic;

namespace GrpcLab09.Services
{
    public class SerwisKotkowWPamieciUlotnej : IKotkiService
    {
        private List<Kotek> kotki = new List<Kotek>();

        public OperationStatusResponse DodajKotka(Kotek k)
        {
            if (kotki.Contains(k))
                return new OperationStatusResponse()
                {
                    Error = true,
                    Msg = "kot z podanym id już istnieje"
                };

            kotki.Add(k);

            return new OperationStatusResponse()
            {
                Error = false,
                Msg = "pomyślnie dodano kota"
            };
        }

        public OperationStatusResponse EdytujKotka(Kotek k)
        {
            var kotekDoEdycji = kotki.Find(k1 => k1.Id == k.Id);

            if (kotekDoEdycji == null)
                return new OperationStatusResponse()
                {
                    Error = true,
                    Msg = "kot o podanym id nie istnieje"
                };

            kotekDoEdycji.Nazwa = k.Nazwa;
            kotekDoEdycji.Waga = k.Waga;

            return new OperationStatusResponse()
            {
                Error = true,
                Msg = "Pomyślnie zaktualizowano kota"
            };
        }

        public List<Kotek> PodajKotki()
        {
            return kotki;
        }

        public void UsunKotka(Kotek k)
        {
            kotki.RemoveAll(k1 => k1.Id == k.Id);
        }
    }
}
