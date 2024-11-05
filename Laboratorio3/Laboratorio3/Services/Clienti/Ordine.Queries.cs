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
        public async Task<IEnumerable<int>> CaricaIdOrdiniConStatoPassatoInInput(StatoOrdine stato)
        {
            return await _dbContext.Ordini
                .Where(x => x.Stato == stato)
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public async Task<int> CaricaIdOrdinePiuCostoso()
        {
            return await _dbContext.Ordini
                .Select(x => new { x.Id, ImportoTotale = x.ProdottiOrdine.Sum(y => y.Quantita * y.Prodotto.Importo) })
                .OrderByDescending(x => x.ImportoTotale)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            // Altra soluzione. L'OrderByDescending accetta un parametro che può essere una lamba expression.
            //
            //return await _dbContext.Ordini
            //    .OrderByDescending(x => x.ProdottiOrdine.Sum(y => y.Quantita * y.Prodotto.Importo))
            //    .Select(x => x.Id)
            //    .FirstOrDefaultAsync();
        }

        public async Task<int> CaricaIdOrdineConPiuProdotti()
        {
            return await _dbContext.Ordini
                .Select(x => new { x.Id, QuantitaTotale = x.ProdottiOrdine.Sum(y => y.Quantita) })
                .OrderByDescending(x => x.QuantitaTotale)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<int>> CaricaIdOrdiniConIdProdottoPassatoInInput(Guid idProdotto)
        {
            return await _dbContext.Ordini
                .Where(x =>x.ProdottiOrdine.Any(y => y.IdProdotto == idProdotto))
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<int>> CaricaIdOrdiniPerIdClientePassatoInInput(Guid idCliente)
        {
            return await _dbContext.Ordini
                .Where(x => x.Utente.IdCliente == idCliente)
                .Select(x => x.Id)
                .ToArrayAsync();

            // Versione alternativa partendo da clienti.
            // Necessario l'uso di SelectMany per appiattire la query. Con il selectMany si può passare da un array di array ad un array.
            // Nel caso specifico si passa da array di clienti ad un array di ordini ma il passaggio non è 1 cliente 1 ordine bensì 1 cliente N ordini
            //
            //return await _dbContext.Clienti
            //    .Where(x => x.Id == idCliente)
            //    .SelectMany(x => x.Utenti.SelectMany(y => y.Ordini))
            //    .Select(x => x.Id)
            //    .ToArrayAsync();
        }
    }
}
