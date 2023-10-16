using Laboratorio4.Services.Clienti;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Laboratorio4.Tests
{
    public class Esercizio1
    {
        ClientiService _clientiService;

        public Esercizio1()
        {
            var context = new ClientiDbContext(new DbContextOptionsBuilder<ClientiDbContext>()
                .UseInMemoryDatabase(databaseName: "Clienti")
                .Options);

            _clientiService = new ClientiService(context);
        }

        [Fact]
        public async void CaricaUtentiAttiviQuery()
        {
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f"),
                Guid.Parse("376299b5-2428-49f2-8374-1d6e9a80467c"),
                Guid.Parse("5d106b64-e592-498e-9421-62c96f85a984"),
                Guid.Parse("95348363-ea0e-43d8-9b6b-c37bb81edaf0"),
                Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272")
            };
            var idsUtentiAttivi = await _clientiService.CaricaUtentiAttiviQuery();

            Assert.NotEmpty(idsUtentiAttivi);
            Assert.Equal(5, idsUtentiAttivi.Count());
            Assert.Equal(idsUtentiAttiviAttesi, idsUtentiAttivi.OrderBy(x => x));
        }

        [Fact]
        public async void CaricaUtentiAttiviDaAlmeno2MesiOrdinatiPerNomeQuery()
        {
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272"),
                Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f"),
            };
            var idsUtentiAttivi = await _clientiService.CaricaUtentiAttiviRegistratiDaAlmeno1MeseOrdinatiPerCognomeQuery();

            Assert.NotEmpty(idsUtentiAttivi);
            Assert.Equal(2, idsUtentiAttivi.Count());
            Assert.Equal(idsUtentiAttiviAttesi, idsUtentiAttivi);
        }

        [Fact]
        public async void CaricaUtentiConEmailCheFinisceConStringaPassataInInput()
        {
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("2178e530-6db6-444d-b2fe-b49a06f06a1f"),
                Guid.Parse("9429e30d-59b5-460b-ad82-9e48217687ba"),
                Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272")
            };
            var idsUtenti = await _clientiService.CaricaUtentiConEmailCheFinisceConStringaPassataInInput("teleworm.us");

            Assert.NotEmpty(idsUtenti);
            Assert.Equal(3, idsUtenti.Count());
            Assert.Equal(idsUtentiAttiviAttesi, idsUtenti.OrderBy(x => x));
        }

        [Fact]
        public async void CaricaUtentiSenzaOrdini()
        {
            var idsUtentiAttiviAttesi = new Guid[] {
                Guid.Parse("376299b5-2428-49f2-8374-1d6e9a80467c"),
                Guid.Parse("69d619b4-fa4e-4784-a3a2-02d7f36d4c77"),
                Guid.Parse("9429e30d-59b5-460b-ad82-9e48217687ba"),
                Guid.Parse("a6cd7ed2-8329-4bf1-b658-d8b815e71272"),
            };
            var idsUtenti = await _clientiService.CaricaUtentiSenzaOrdini();

            Assert.NotEmpty(idsUtenti);
            Assert.Equal(4, idsUtenti.Count());
            Assert.Equal(idsUtentiAttiviAttesi, idsUtenti.OrderBy(x => x));
        }
    }
}