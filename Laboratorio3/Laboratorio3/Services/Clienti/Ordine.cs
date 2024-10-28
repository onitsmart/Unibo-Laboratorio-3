using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio3.Services.Clienti
{
    public class Ordine
    {
        [Key]
        public int Id { get; set; }

        public string NumeroIdentificativoPerUtente { get; set; }

        public DateTime DataCreazione { get; set; }

        public StatoOrdine Stato { get; set; }
        public DateTime? DataConsegna { get; set; }

        public string Note { get; set; }

        public Guid IdUtente { get; set; }
        [ForeignKey(nameof(IdUtente))]
        [InverseProperty("Ordini")]
        public Utente Utente { get; set; }

        public IEnumerable<ProdottoOrdine> ProdottiOrdine { get; set; }
    }

    public enum StatoOrdine
    {
        Ricevuto = 0,
        InPreparazione = 1,
        InTransito = 2,
        InConsegna = 3,
        Consegnato = 4,
        Annullato = 5,
        Reso = 6
    }
}
