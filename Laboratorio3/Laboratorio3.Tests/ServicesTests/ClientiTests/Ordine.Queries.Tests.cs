using Laboratorio3.Services.Clienti;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laboratorio3.Tests.ServicesTests.ClientiTests
{
    // MEDIUM-HARD
    public class OrdineQueriesTests
    {
        ClientiService _clientiService;

        public OrdineQueriesTests()
        {
            var context = new ClientiDbContext(new DbContextOptionsBuilder<ClientiDbContext>()
                .UseInMemoryDatabase(databaseName: "Clienti")
                .Options);

            _clientiService = new ClientiService(context);
        }

        public static IEnumerable<object[]> TestData_CaricaOrdiniConStatoPassatoInInput = new List<object[]>
        {
            new object[] {
                StatoOrdine.InTransito,
                new int[]
                {
                    1
                }
            },
            new object[] {
                StatoOrdine.Reso,
                new int[]
                {
                    2
                }
            }
        };
        [Theory]
        [MemberData(nameof(TestData_CaricaOrdiniConStatoPassatoInInput))]
        public async Task CaricaOrdini_ConStatoPassatoInInput(StatoOrdine input, IEnumerable<int> valoriAttesi)
        {
            var idsOrdini = await _clientiService.CaricaIdOrdiniConStatoPassatoInInput(input);
            var idsOrdiniOrdinati = idsOrdini.OrderBy(x => x);

            Assert.Equal(valoriAttesi, idsOrdiniOrdinati);
        }

        // Migliora ciò che hai scritto nel test precedente per far passare anche questo test
        [Fact]
        public async void CaricaOrdini_ConStatoPassatoInInput_CasoNullo()
        {
            var valoriAttesi = Array.Empty<int>();

            var idsOrdini = await _clientiService.CaricaIdOrdiniConStatoPassatoInInput(StatoOrdine.InConsegna);
            var idsOrdiniOrdinati = idsOrdini.OrderBy(x => x);

            Assert.Equal(valoriAttesi, idsOrdiniOrdinati);
        }

        [Fact]
        public async Task CaricaOrdine_PiuCostoso()
        {
            var valoreAtteso = 3;

            var idOrdinePiuCostoso = await _clientiService.CaricaIdOrdinePiuCostoso();

            Assert.Equal(valoreAtteso, idOrdinePiuCostoso);
        }

        [Fact]
        // Si parla di quantità, non mi interessano i prodotti univoci, mettete tutto insieme. 50 viti > 1 vite + 1 bullone
        public async Task CaricaOrdine_ConPiuProdotti()
        {
            var valoreAtteso = 1;

            var idOrdineConPiuProdotti = await _clientiService.CaricaIdOrdineConPiuProdotti();

            Assert.Equal(valoreAtteso, idOrdineConPiuProdotti);
        }

        public static IEnumerable<object[]> TestData_CaricaOrdiniConIdProdottoPassatoInInput = new List<object[]>
        {
            new object[] {
                Guid.Parse("100276f3-2247-4852-9a6e-7c50ce878245"),
                new int[]
                {
                    1,
                    2
                }
            },
            new object[] {
                Guid.Parse("37681b04-8edf-4fd4-9d52-b8b01c8afe40"),
                new int[]
                {
                    3
                }
            },
            new object[] {
                Guid.Parse("ea044234-0828-43f2-92dd-79141641c444"),
                Array.Empty<int>()
            }
        };
        [Theory]
        [MemberData(nameof(TestData_CaricaOrdiniConIdProdottoPassatoInInput))]
        public async Task CaricaOrdini_ConIdProdottoPassatoInInput(Guid input, IEnumerable<int> valoriAttesi)
        {
            var idsOrdini = await _clientiService.CaricaIdOrdiniConIdProdottoPassatoInInput(input);
            var idsOrdiniOrdinati = idsOrdini.OrderBy(x => x);

            Assert.Equal(valoriAttesi, idsOrdiniOrdinati);
        }

        public static IEnumerable<object[]> TestData_CaricaOrdiniPerIdClientePassatoInInput = new List<object[]>
        {
            new object[] {
                Guid.Parse("e9d337f5-2ce7-4506-8fed-fdf03f301693"),
                new int[]
                {
                    1,
                    3
                }
            },
            new object[] {
                Guid.Parse("8428529f-9fd1-4bff-b4b5-dfda6b842d56"),
                Array.Empty<int>()
            }
        };
        [Theory]
        [MemberData(nameof(TestData_CaricaOrdiniPerIdClientePassatoInInput))]
        public async Task CaricaOrdini_PerIdClientePassatoInInput(Guid input, IEnumerable<int> valoriAttesi)
        {
            var idOrdini = await _clientiService.CaricaIdOrdiniPerIdClientePassatoInInput(input);

            Assert.Equal(valoriAttesi, idOrdini);
        }
    }
}
