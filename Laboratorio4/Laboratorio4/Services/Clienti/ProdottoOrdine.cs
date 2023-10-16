using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio4.Services.Clienti
{
    public class ProdottoOrdine
    {
        [Key]
        public int Id { get; set; }

        public int Quantita { get; set; }

        public Guid IdProdotto { get; set; }
        [ForeignKey(nameof(IdProdotto))]
        [InverseProperty("Ordini")]
        public Prodotto Prodotto { get; set; }

        public int IdOrdine { get; set; }
        [ForeignKey(nameof(IdOrdine))]
        [InverseProperty("ProdottiOrdine")]
        public Ordine Ordine { get; set; }
    }
}
