using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio3.Services.Clienti
{
    public partial class ClientiService
    {
        public async Task<IEnumerable<Guid>> CercaIdClientiConFiltriPassatiInInput(string filtroNomeCliente, string filtroNomeUtente, StatoOrdine? statoOrdine, DateTime? dataMinimaCreazioneOrdine)
        {
            var linq = _dbContext.Clienti.AsQueryable();

            if (string.IsNullOrWhiteSpace(filtroNomeCliente) == false)
            {
                linq = linq.Where(x => x.Nome.Contains(filtroNomeCliente, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(filtroNomeUtente) == false)
            {
                linq = linq.Where(x => x.Utenti.Any(y => y.Nome.Contains(filtroNomeUtente, StringComparison.OrdinalIgnoreCase)));
            }

            if (statoOrdine != null)
            {
                linq = linq.Where(x => x.Utenti.Any(y => y.Ordini.Any(z => z.Stato == statoOrdine)));
            }

            if (dataMinimaCreazioneOrdine != null)
            {
                linq = linq.Where(x => x.Utenti.Any(y => y.Ordini.Any(z => z.DataCreazione >= dataMinimaCreazioneOrdine)));
            }

            return await linq
                .Select(x => x.Id)
                .ToArrayAsync();
        }
    }
}
