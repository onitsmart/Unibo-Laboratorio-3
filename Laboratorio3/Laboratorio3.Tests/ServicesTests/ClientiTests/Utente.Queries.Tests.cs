using Laboratorio3.Services.Clienti;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static Laboratorio3.Services.Clienti.ClientiService;

namespace Laboratorio3.Tests.ServicesTests.ClientiTests
{
    /*
     * OPERAZIONI UTILI IN LINQ
     * 
     * .Where => Filtro
     * .Take => Seleziona solo un numero limitato di elementi
     * .Skip => Non seleziona i primi N elementi
     * 
     * .Select => Seleziono una parte dell'oggetto in input
     * .SelectMany => Appiattisce. Da un array di array ad un semplice array
     * .ToArray => Seleziona gli elementi risultanti dall'interrogazione e li inserisce in un array
     * .ToList => Seleziona gli elementi risultanti dall'interrogazione e li inserisce in una lista
     * .FirstOrDefault => Il primo elemento o il default per il tipo di elemento cercato
     * .First => Come sopra ma va in eccezione se non c'� nulla
     * .Single => 1 ed 1 solo elemento. Se ne trova 2 va in eccezione
     * 
     * .Count => Conta gi elementi risultanti
     * .OrderBy => Ordinamento
     * .GroupBy => Raggruppamento
     * .Any => true se un elemento rispetta la condizione
     * .All => true se tutti gli elementi della lista rispettano la condizione
     * 
     * https://learn.microsoft.com/it-it/dotnet/csharp/linq/standard-query-operators/
     * 
     */

    // EASY
    public class UtenteQueriesTests
    {
        ClientiService _clientiService;

        public UtenteQueriesTests()
        {
            var context = new ClientiDbContext(new DbContextOptionsBuilder<ClientiDbContext>()
                .UseInMemoryDatabase(databaseName: "Clienti")
                .Options);

            _clientiService = new ClientiService(context);
        }

        [Fact]
        public async Task CaricaUtenti_Attivi()
        {
            // Arrange
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f"),
                Guid.Parse("376299b5-2428-49f2-8374-1d6e9a80467c"),
                Guid.Parse("5d106b64-e592-498e-9421-62c96f85a984"),
                Guid.Parse("95348363-ea0e-43d8-9b6b-c37bb81edaf0"),
                Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272")
            };

            // Act
            var idsUtentiAttivi = await _clientiService.CaricaIdUtentiAttivi();
            var idsUtentiAttiviOrdinati = idsUtentiAttivi.OrderBy(x => x);

            // Assert
            Assert.Equal(idsUtentiAttiviAttesi, idsUtentiAttiviOrdinati);
        }

        // Includi gli utenti registrati esattamente un mese fa
        [Fact]
        public async Task CaricaUtenti_AttiviRegistratiDaAlmeno1MeseOrdinatiPerCognome()
        {
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272"),
                Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f"),
            };

            var idsUtentiAttivi = await _clientiService.CaricaIdUtentiAttiviRegistratiDaAlmeno1MeseOrdinatiPerCognome();

            Assert.Equal(idsUtentiAttiviAttesi, idsUtentiAttivi);
        }

        public static IEnumerable<object[]> TestData_CaricaUtentiConEmailCheFinisceConStringaPassataInInput = new List<object[]>
        {
            new object[] {
                "teleworm.us",
                new Guid[] {
                    Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f"),
                    Guid.Parse("9429e30d-59b5-460b-ad82-9e48217687ba"),
                    Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272")
                }
            },
            new object[] {
                "armyspy.com",
                new Guid[] {
                    Guid.Parse("69d619b4-fa4e-4784-a3a2-02d7f36d4c77")
                }
            },
            new object[] {
                "asdf",
                Array.Empty<Guid>()
            }
        };
        // Case sensitivity non � rilevante
        [Theory]
        [MemberData(nameof(TestData_CaricaUtentiConEmailCheFinisceConStringaPassataInInput))]
        public async Task CaricaUtenti_ConEmailCheFinisceConStringaPassataInInput(string input, IEnumerable<Guid> valoriAttesi)
        {
            var idsUtenti = await _clientiService.CaricaIdUtentiConEmailCheFinisceConStringaPassataInInput(input);
            var idsUtentiOrdinati = idsUtenti.OrderBy(x => x);

            Assert.Equal(valoriAttesi, idsUtentiOrdinati);
        }

        // Migliora ci� che hai scritto nel test precedente per far passare anche questo test
        [Fact]
        public async Task CaricaUtenti_ConEmailCheFinisceConStringaPassataInInput_CasoNullo()
        {
            var idsUtentiAttesi = Array.Empty<Guid>();

            var idsUtenti = await _clientiService.CaricaIdUtentiConEmailCheFinisceConStringaPassataInInput(null);
            var idsUtentiOrdinati = idsUtenti.OrderBy(x => x);

            Assert.Equal(idsUtentiAttesi, idsUtenti);
        }

        [Fact]
        public async Task CaricaUtenti_SenzaOrdini()
        {
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("376299b5-2428-49f2-8374-1d6e9a80467c"),
                Guid.Parse("69d619b4-fa4e-4784-a3a2-02d7f36d4c77"),
                Guid.Parse("9429e30d-59b5-460b-ad82-9e48217687ba"),
                Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272"),
            };

            var idsUtenti = await _clientiService.CaricaIdUtentiSenzaOrdini();

            Assert.Equal(idsUtentiAttiviAttesi, idsUtenti.OrderBy(x => x));
        }

        [Fact]
        public async Task CaricaUtenti_PerClientePassatoInInput()
        {
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("376299b5-2428-49f2-8374-1d6e9a80467c"),
                Guid.Parse("5d106b64-e592-498e-9421-62c96f85a984"),
                Guid.Parse("9429e30d-59b5-460b-ad82-9e48217687ba"),
                Guid.Parse("95348363-ea0e-43d8-9b6b-c37bb81edaf0"),
            };

            var idsUtenti = await _clientiService.CaricaIdUtentiPerClientePassatoInInput(Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"));

            Assert.Equal(idsUtentiAttiviAttesi, idsUtenti.OrderBy(x => x));
        }

        [Fact]
        public async Task CaricaUtente_CheHaFattoOrdinePassatoInInput()
        {
            var utente = await _clientiService.CaricaUtenteCheHaFattoOrdinePassatoInInput(1);

            Assert.Equivalent(
                new UtenteInfoDTO
                {
                    Id = Guid.Parse("5d106b64-e592-498e-9421-62c96f85a984"),
                    Nome = "Lavinia",
                    CodiceRicercaClienteACuiAppartieneUtente = "C00154"
                },
                utente);
        }

        // Migliora ci� che hai scritto nel test precedente per far passare anche questo test
        [Fact]
        public async Task CaricaUtente_CheHaFattoOrdinePassatoInInput_OrdineNullo()
        {
            var utenteNullo = await _clientiService.CaricaUtenteCheHaFattoOrdinePassatoInInput(5);

            Assert.Null(utenteNullo);
        }

        public static IEnumerable<object[]> TestData_ContaUtentiPerIdClientePassatoInInput = new List<object[]>
        {
            new object[] {
                Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                4
            },
            new object[] {
                Guid.Parse("90a40f7f-b750-4c09-9aca-837440d78d47"),
                2
            },
            new object[] {
                Guid.Parse("8428529f-9fd1-4bff-b4b5-dfda6b842d56"),
                1
            },
            new object[] {
                Guid.Parse("5d106b64-e592-498e-9421-62c96f85a984"),
                0
            }
        };
        [Theory]
        [MemberData(nameof(TestData_ContaUtentiPerIdClientePassatoInInput))]
        public async Task ContaUtenti_PerIdClientePassatoInInput(Guid input, int valoreAtteso)
        {
            var conteggio = await _clientiService.ContaUtentiPerIdClientePassatoInInput(input);

            Assert.Equal(valoreAtteso, conteggio);
        }
    }
}