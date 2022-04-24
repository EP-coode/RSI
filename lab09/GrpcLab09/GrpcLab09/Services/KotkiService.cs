using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcLab09.Services;

namespace GrpcLab09
{
    public class KotkiService : Kociarnia.KociarniaBase
    {
        private readonly IKotkiService _kotkiService;

        public KotkiService(IKotkiService kotkiService)
        {
            _kotkiService = kotkiService;
        }

        public OperationStatusResponse DodajKotka(Kotek k)
        {
            return _kotkiService.DodajKotka(k);
        }

        public ListaKotow PodajKotki()
        {
            ListaKotow lk = new ListaKotow();
            lk.Kotki.AddRange(_kotkiService.PodajKotki());
            return lk;
        }

        public EmptyResponse UsunKotka(Kotek k)
        {
            _kotkiService.UsunKotka(k);
            return new EmptyResponse();
        }

        public OperationStatusResponse EdytujKotka(Kotek k)
        {
            return _kotkiService.EdytujKotka(k);
        }
    }
}
