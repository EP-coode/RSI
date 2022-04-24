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

        public override Task<OperationStatusResponse> DodajKotka(Kotek request, ServerCallContext context)
        {
            return Task.FromResult(_kotkiService.DodajKotka(request));
        }



        public override Task<ListaKotow> PodajKotki(ParametryWyszukiwaniaKotkow request, ServerCallContext context)
        {
            ListaKotow lk = new ListaKotow();
            lk.Kotki.AddRange(_kotkiService.PodajKotki());
            return Task.FromResult(lk);
        }

        public override Task<EmptyResponse> UsunKotka(Kotek k, ServerCallContext context)
        {
            _kotkiService.UsunKotka(k);
            return Task.FromResult(new EmptyResponse());
        }

        public override Task<OperationStatusResponse> EdytujKotka(Kotek k, ServerCallContext context)
        {
            return Task.FromResult(_kotkiService.EdytujKotka(k));
        }
    }
}
