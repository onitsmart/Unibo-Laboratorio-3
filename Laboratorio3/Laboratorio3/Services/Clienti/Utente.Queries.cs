using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3.Services.Clienti
{
    public partial class ClientiService
    {
        public async Task<IEnumerable<Guid>> CaricaIdUtentiAttivi()
        {
            return await _dbContext.Utenti
                .Where(x => x.Attivo)
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiAttiviRegistratiDaAlmeno1MeseOrdinatiPerCognome()
        {
            var dataLimite = DateTime.Now.AddMonths(-1);

            return await _dbContext.Utenti
                .Where(x => x.Attivo && x.DataCreazione <= dataLimite)
                .OrderBy(x => x.Cognome)
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiConEmailCheFinisceConStringaPassataInInput(string stringaFinale)
        {
            return await _dbContext.Utenti
                .Where(x => stringaFinale != null && x.Email.EndsWith(stringaFinale)) // stringFinale != null per evitare che EndsWith vada in eccezione con stringa nulla
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiSenzaOrdini()
        {
            return await _dbContext.Utenti
                .Where(x => x.Ordini.Any() == false) // L'elenco degli ordini associato all'utente non contiene alcun elemento
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Guid>> CaricaIdUtentiPerClientePassatoInInput(Guid idCliente)
        {
            return await _dbContext.Utenti
                .Where(x => x.IdCliente == idCliente)
                .Select(x => x.Id)
                .ToArrayAsync();
        }

        public class UtenteInfoDTO
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }

            public string CodiceRicercaClienteACuiAppartieneUtente { get; set; }
        }
        public async Task<UtenteInfoDTO> CaricaUtenteCheHaFattoOrdinePassatoInInput(int idOrdine)
        {
            return await _dbContext.Utenti
                .Where(x => x.Ordini.Any(y => y.Id == idOrdine))
                .Select(x => new UtenteInfoDTO
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CodiceRicercaClienteACuiAppartieneUtente = x.Cliente.CodiceRicerca
                }).FirstOrDefaultAsync();
        }

        public async Task<int> ContaUtentiPerIdClientePassatoInInput(Guid idCliente)
        {
            return await _dbContext.Utenti
                .Where(x => x.IdCliente == idCliente)
                .CountAsync();
        }
    }
}
