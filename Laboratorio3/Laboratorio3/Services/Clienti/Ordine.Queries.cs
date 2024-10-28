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
            throw new NotImplementedException();
        }

        public async Task<int> CaricaIdOrdinePiuCostoso()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CaricaIdOrdineConPiuProdotti()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<int>> CaricaIdOrdiniConIdProdottoPassatoInInput(Guid idProdotto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<int>> CaricaIdOrdiniPerIdClientePassatoInInput(Guid idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
