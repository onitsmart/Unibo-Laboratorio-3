using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio4.Services.Clienti
{
    public partial class ClientiService
    {
        public async Task<IEnumerable<Guid>> CaricaUtentiAttiviQuery()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guid>> CaricaUtentiAttiviRegistratiDaAlmeno1MeseOrdinatiPerCognomeQuery()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guid>> CaricaUtentiConEmailCheFinisceConStringaPassataInInput(string stringaFinale)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guid>> CaricaUtentiSenzaOrdini()
        {
            throw new NotImplementedException();
        }
    }
}
