using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio3.Services.Clienti
{
    public class Utente
    {
        [Key]
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string EncryptedPassword { get; set; }

        public DateTime DataCreazione { get; set; }
        public DateTime DataModifica { get; set; }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime? DataDiNascita { get; set; }

        public bool Attivo { get; set; }

        public Guid IdCliente { get; set; }
        [ForeignKey(nameof(IdCliente))]
        [InverseProperty("Utenti")]
        public Cliente Cliente { get; set; }

        public IEnumerable<Ordine> Ordini {get; set; }
    }
}
