using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio4.Services.Clienti
{
    public partial class ClientiService
    {
        public async Task<IEnumerable<Guid>> CaricaIdUtentiAttivi()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiAttiviRegistratiDaAlmeno1MeseOrdinatiPerCognome()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiConEmailCheFinisceConStringaPassataInInput(string stringaFinale)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiSenzaOrdini()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiPerClientePassatoInInput(Guid idCliente)
        {
            throw new NotImplementedException();
        }

        public class UtenteInfoDTO
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }

            public string CodiceRicercaClienteACuiAppartieneUtente { get; set; }
        }
        public async Task<UtenteInfoDTO> CaricaUtenteCheHaFattoOrdinePassatoInInput(int idOrdine)
        {
            throw new NotImplementedException();
        }

        public async Task<int> ContaUtentiPerIdClientePassatoInInput(Guid idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
