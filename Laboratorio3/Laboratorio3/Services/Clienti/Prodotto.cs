using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio3.Services.Clienti
{
    public class Prodotto
    {
        [Key]
        public Guid Id { get; set; }

        public string Codice { get; set; }

        public string Nome { get; set; }

        public decimal Importo { get; set; }

        public int QuantitaDisponibile { get; set; }

        public DateTime UltimaModifica { get; set; }

        public decimal PesoKg { get; set; }

        public IEnumerable<ProdottoOrdine> Ordini { get; set; }
    }
}
