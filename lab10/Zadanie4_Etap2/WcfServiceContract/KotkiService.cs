using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfServiceContract
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class KotkiService : IKotkiService
    {
        static List<Kotek> kotki = new List<Kotek>();
        IKotkiServiceCallback kotkiCallback = null;

        public KotkiService()
        {
            kotkiCallback = OperationContext.Current.GetCallbackChannel<IKotkiServiceCallback>();
        }

        public void DodajKotka(Kotek k)
        {
            kotki.Add(k);
            kotkiCallback.AddKotekResult(kotki);
        }

        public void GetKotki()
        {
            kotkiCallback.GetKotkiResult(kotki);
        }

        public void GetKotkiByGender(Plec p)
        {
            var kotkiWybranejPlci = kotki.Where(kotek => kotek.plec == p).ToList();
            Thread.Sleep(2000);
            kotkiCallback.GetKotkiByPlec(kotkiWybranejPlci);
        }

        public void RemoveKotek(int idKotka)
        {
            var kotekToRemove = kotki.Find(k => k.id == idKotka);

            if (kotekToRemove == null)
                return;

            kotki = kotki.Where(k => k != kotekToRemove).ToList();

            kotkiCallback.DeleteKotekResult(kotekToRemove);
        }
    }
}
