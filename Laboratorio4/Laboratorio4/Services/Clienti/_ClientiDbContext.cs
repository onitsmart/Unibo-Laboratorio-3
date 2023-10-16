using Laboratorio4.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio4.Services.Clienti
{
    public class ClientiDbContext : DbContext
    {
        public ClientiDbContext()
        {
        }

        public ClientiDbContext(DbContextOptions<ClientiDbContext> options) : base(options)
        {
            DataGenerator.InitializeClienti(this);
        }

        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<ProdottoOrdine> ProdottiOrdini { get; set; }
    }
}
