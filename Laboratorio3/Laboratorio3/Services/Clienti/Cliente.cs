using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio3.Services.Clienti
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        public string RagioneSociale { get; set; }

        public bool Attivo { get; set; }

        public string Nome { get; set; }
        public string CodiceRicerca { get; set; }

        public string Citta { get; set; }

        public IEnumerable<Utente> Utenti { get; set; }
    }
}
