using Laboratorio3.Services.Clienti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Laboratorio3.Infrastructure
{
    public class DataGenerator
    {
        // Serve solo perchè abbiamo un progettino di test che esegue più volte l'Initialize in concorrenza
        private static object Lock = new();

        public static void InitializeClienti(ClientiDbContext context)
        {
            var now = DateTime.Now;

            if (context.Clienti.Any())
            {
                return;   // Data was already seeded
            }

            lock (Lock)
            {
                if (context.Clienti.Any())
                {
                    return;   // Data was already seeded
                }

                context.Clienti.AddRange(
                    new Cliente
                    {
                        Id = Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                        RagioneSociale = "Pippo spa",
                        Nome = "Pippo & paperino",
                        Citta = "Cesena",
                        CodiceRicerca = "C00154",
                        Attivo = true
                    },
                    new Cliente
                    {
                        Id = Guid.Parse("90a40f7f-b750-4c09-9aca-837440d78d47"),
                        RagioneSociale = "Full Color & UI management",
                        Nome = "Full color",
                        Citta = "Bologna",
                        CodiceRicerca = "C00176",
                        Attivo = true
                    },
                    new Cliente
                    {
                        Id = Guid.Parse("8428529f-9fd1-4bff-b4b5-dfda6b842d56"),
                        RagioneSociale = "Paperino & co",
                        Nome = "Paperino",
                        Citta = "Cesena",
                        CodiceRicerca = "C00182",
                        Attivo = false,
                    });

                context.Utenti.AddRange(
                    new Utente
                    {
                        Id = Guid.Parse("5d106b64-e592-498e-9421-62c96f85a984"),
                        Email = "LaviniaLucchese@rhyta.com",
                        EncryptedPassword = "7ce8e061d624abb3a5119e14e44b556504c9cb5d497dbd806f073254e548e120",
                        Attivo = true,
                        Nome = "Lavinia",
                        Cognome = "Lucchese",
                        DataDiNascita = new DateTime(1989, 8, 23),
                        DataCreazione = now,
                        DataModifica = now,
                        IdCliente = Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693")
                    },
                    new Utente
                    {
                        Id = Guid.Parse("95348363-ea0e-43d8-9b6b-c37bb81edaf0"),
                        Email = "GermanoMancini@dayrep.com",
                        EncryptedPassword = "f8e0e28c2867348f129e39e881df8ed736a23b903cf001e58ded899427f4c497",
                        Attivo = true,
                        Nome = "Germano",
                        Cognome = "Mancini",
                        DataDiNascita = new DateTime(1965, 5, 29),
                        DataCreazione = DateTime.Now.AddDays(-10),
                        DataModifica = now,
                        IdCliente = Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693")
                    },
                    new Utente
                    {
                        Id = Guid.Parse("376299b5-2428-49f2-8374-1d6e9a80467c"),
                        Email = "EricaNapolitani@dayrep.com",
                        EncryptedPassword = "610b76c7696dbf356f5cf3e24fdd093483b05f760951c70b60d67a307814433f",
                        Attivo = true,
                        Nome = "Erica",
                        Cognome = "Napolitani",
                        DataDiNascita = new DateTime(1968, 12, 13),
                        DataCreazione = DateTime.Now.AddDays(-15),
                        DataModifica = DateTime.Now.AddDays(-15),
                        IdCliente = Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693")
                    },
                    new Utente
                    {
                        Id = Guid.Parse("9429e30d-59b5-460b-ad82-9e48217687ba"),
                        Email = "SandraFanucci@teleworm.us",
                        EncryptedPassword = "1666ed600217065dfb7d2c72d1c4a8984a28d61aea774ab623306c883c25c132",
                        Attivo = false,
                        Nome = "Sandra",
                        Cognome = "Fanucci",
                        DataDiNascita = new DateTime(2003, 4, 29),
                        DataCreazione = DateTime.Now.AddYears(-1),
                        DataModifica = DateTime.Now.AddYears(-1),
                        IdCliente = Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693")
                    },
                    new Utente
                    {
                        Id = Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f"),
                        Email = "LivioPugliesi@teleworm.us",
                        EncryptedPassword = "7912bc0aea771cd899ad80c67b55ec05e5ac0f05f3308cae1452590e5aee197a",
                        Attivo = true,
                        Nome = "Livio",
                        Cognome = "Pugliesi",
                        DataDiNascita = new DateTime(2003, 10, 13),
                        DataCreazione = DateTime.Now.AddYears(-3),
                        DataModifica = DateTime.Now.AddYears(-3),
                        IdCliente = Guid.Parse("90a40f7f-b750-4c09-9aca-837440d78d47")
                    },
                    new Utente
                    {
                        Id = Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272"),
                        Email = "MassimoGreco@teleworm.us",
                        EncryptedPassword = "1666ed600217065dfb7d2c72d1c4a8984a28d61aea774ab623306c883c25c132",
                        Attivo = true,
                        Nome = "Massimo",
                        Cognome = "Greco",
                        DataDiNascita = new DateTime(2003, 4, 29),
                        DataCreazione = DateTime.Now.AddMonths(-1),
                        DataModifica = DateTime.Now.AddMonths(-1),
                        IdCliente = Guid.Parse("90a40f7f-b750-4c09-9aca-837440d78d47")
                    },
                    new Utente
                    {
                        Id = Guid.Parse("69d619b4-fa4e-4784-a3a2-02d7f36d4c77"),
                        Email = "EdmondaSicilianiteleworm.us@armyspy.com",
                        EncryptedPassword = "64112d15053deedacf23acbc14a39f80c3b3fd0bca1a3f567ec6fc58c6263f31",
                        Attivo = false,
                        Nome = "Edmonda",
                        Cognome = "Siciliani",
                        DataDiNascita = new DateTime(2003, 4, 29),
                        DataCreazione = DateTime.Now.AddYears(-1),
                        DataModifica = DateTime.Now.AddYears(-1),
                        IdCliente = Guid.Parse("8428529f-9fd1-4bff-b4b5-dfda6b842d56")
                    });

                context.Prodotti.AddRange(
                    new Prodotto
                    {
                        Id = Guid.Parse("100276f3-2247-4852-9a6e-7c50ce878245"),
                        Codice = "SED002",
                        Nome = "Sedia moderna",
                        Importo = 50.25M,
                        QuantitaDisponibile = 120,
                        UltimaModifica = DateTime.Now.AddDays(-10),
                        PesoKg = 20
                    },
                    new Prodotto
                    {
                        Id = Guid.Parse("37681b04-8edf-4fd4-9d52-b8b01c8afe40"),
                        Codice = "ELI001",
                        Nome = "Elicottero",
                        Importo = 500000M,
                        QuantitaDisponibile = 2,
                        UltimaModifica = DateTime.Now.AddDays(-15),
                        PesoKg = 5000
                    },
                    new Prodotto
                    {
                        Id = Guid.Parse("6e798c90-e0b2-4f55-a1cc-97077cc5aa1c"),
                        Codice = "BOT023",
                        Nome = "Bottiglia in alluminio",
                        Importo = 12.99M,
                        QuantitaDisponibile = 30,
                        UltimaModifica = DateTime.Now.AddDays(-2),
                        PesoKg = 0.50M
                    },
                    new Prodotto
                    {
                        Id = Guid.Parse("ea044234-0828-43f2-92dd-79141641c444"),
                        Codice = "SMR135",
                        Nome = "Smartphone",
                        Importo = 650M,
                        QuantitaDisponibile = 0,
                        UltimaModifica = DateTime.Now,
                        PesoKg = 0.250M
                    },
                    new Prodotto
                    {
                        Id = Guid.Parse("e5a58a7d-3631-4b6e-8456-f5c21d045cdd"),
                        Codice = "TAV023",
                        Nome = "Tavolo",
                        Importo = 175.99M,
                        QuantitaDisponibile = 45,
                        UltimaModifica = DateTime.Now.AddDays(-12),
                        PesoKg = 120
                    });

                context.Ordini.AddRange(
                    new Ordine
                    {
                        Id = 1,
                        NumeroIdentificativoPerUtente = "ORD-01234",
                        DataCreazione = DateTime.Now,
                        Stato = StatoOrdine.InTransito,
                        DataConsegna = DateTime.Now.AddDays(10),
                        Note = "Consegnate alle svelta",
                        IdUtente = Guid.Parse("5d106b64-e592-498e-9421-62c96f85a984")
                    },
                    new Ordine
                    {
                        Id = 2,
                        NumeroIdentificativoPerUtente = "ORD-12345",
                        DataCreazione = DateTime.Now.AddMonths(-2),
                        Stato = StatoOrdine.Reso,
                        DataConsegna = DateTime.Now.AddMonths(-1),
                        IdUtente = Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f")
                    },
                    new Ordine
                    {
                        Id = 3,
                        NumeroIdentificativoPerUtente = "ORD-87568",
                        DataCreazione = DateTime.Now,
                        Stato = StatoOrdine.Ricevuto,
                        Note = "Lasciare in giardino",
                        IdUtente = Guid.Parse("95348363-ea0e-43d8-9b6b-c37bb81edaf0")
                    });

                context.ProdottiOrdini.AddRange(
                    new ProdottoOrdine
                    {
                        Id = 1,
                        Quantita = 3,
                        IdProdotto = Guid.Parse("e5a58a7d-3631-4b6e-8456-f5c21d045cdd"),
                        IdOrdine = 1,
                    },
                    new ProdottoOrdine
                    {
                        Id = 2,
                        Quantita = 2,
                        IdProdotto = Guid.Parse("37681b04-8edf-4fd4-9d52-b8b01c8afe40"),
                        IdOrdine = 3,
                    },
                    new ProdottoOrdine
                    {
                        Id = 3,
                        Quantita = 1,
                        IdProdotto = Guid.Parse("e5a58a7d-3631-4b6e-8456-f5c21d045cdd"),
                        IdOrdine = 1,
                    },
                    new ProdottoOrdine
                    {
                        Id = 4,
                        Quantita = 45,
                        IdProdotto = Guid.Parse("100276f3-2247-4852-9a6e-7c50ce878245"),
                        IdOrdine = 1,
                    },
                    new ProdottoOrdine
                    {
                        Id = 5,
                        Quantita = 46,
                        IdProdotto = Guid.Parse("100276f3-2247-4852-9a6e-7c50ce878245"),
                        IdOrdine = 2,
                    });

                context.SaveChanges();
            }
        }
    }
}
