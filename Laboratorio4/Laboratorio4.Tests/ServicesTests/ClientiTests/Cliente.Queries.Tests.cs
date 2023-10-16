using Laboratorio4.Services.Clienti;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static Laboratorio4.Services.Clienti.ClientiService;

namespace Laboratorio4.Tests.ServicesTests.ClientiTests
{
    // HARDER
    public class ClienteQueriesTests
    {
        ClientiService _clientiService;

        public ClienteQueriesTests()
        {
            var context = new ClientiDbContext(new DbContextOptionsBuilder<ClientiDbContext>()
                .UseInMemoryDatabase(databaseName: "Clienti")
                .Options);

            _clientiService = new ClientiService(context);
        }

        public static IEnumerable<object?[]> TestData_CaricaClientiConFiltriPassatiInInput = new List<object?[]>
        {
            new object?[] {
                null,
                null,
                null,
                null,
                new Guid[]
                {
                    Guid.Parse("8428529f-9fd1-4bff-b4b5-dfda6b842d56"),
                    Guid.Parse("90a40f7f-b750-4c09-9aca-837440d78d47"),
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
            new object?[] {
                "paperino",
                null,
                null,
                null,
                new Guid[]
                {
                    Guid.Parse("8428529f-9fd1-4bff-b4b5-dfda6b842d56"),
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
            new object?[] {
                null,
                "Lavinia",
                null,
                null,
                new Guid[]
                {
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
            new object?[] {
                "paperino",
                "Lavinia",
                null,
                null,
                new Guid[]
                {
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
            new object?[] {
                null,
                null,
                StatoOrdine.Ricevuto,
                null,
                new Guid[]
                {
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
            new object?[] {
                null,
                null,
                null,
                DateTime.Now.AddYears(-2),
                new Guid[]
                {
                    Guid.Parse("90a40f7f-b750-4c09-9aca-837440d78d47"),
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
            new object?[] {
                null,
                "Lavinia",
                null,
                DateTime.Now.AddYears(-2),
                new Guid[]
                {
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
            new object?[] {
                "paperino",
                "Lavinia",
                StatoOrdine.Ricevuto,
                DateTime.Now.AddYears(-2),
                new Guid[]
                {
                    Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                }
            },
        };
        [Theory]
        [MemberData(nameof(TestData_CaricaClientiConFiltriPassatiInInput))]
        public async void CaricaClienti_ConFiltriPassatiInInput(string filtroNomeCliente, string filtroNomeUtente, StatoOrdine? stato, DateTime? minimaDataCreazioneOrdine, IEnumerable<Guid> valoriAttesi)
        {
            var idsClienti = await _clientiService.CercaIdClientiConFiltriPassatiInInput(filtroNomeCliente, filtroNomeUtente, stato, minimaDataCreazioneOrdine);
            var idsClientiOrdinati = idsClienti.OrderBy(x => x);

            Assert.Equal(valoriAttesi, idsClientiOrdinati);
        }
    }
}