using SistemaVentas.App.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace SistemaVentas.ApiTests.ApiTests.ProductApiTests
{
    public class GetAllApiTests(ApiApp apiApp) : IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();

        [Fact]
        public async Task GetAllProducts_ReturnsOkResponse()
        {
            //Arrange Act
            var response = await _client.GetAsync($"{apiApp.PathProductApi}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnsTwoOMoreProducts_WhenStatusIs200()
        {
            //Arrange
            var response = await _client.GetAsync($"{apiApp.PathProductApi}");
           
            //Act
            var content = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(content!.Count >= 2);
        }

        [Fact]
        public async Task FiltrarProductosPorCategoria_CuandoCategoriaExiste_RetornaProductosDeEsaCategoria()
        {
            //Arrange
            string categoryExpected = "Ropa";
            int categoryId = 2;

            //Act
            var response = await _client.GetAsync($"{apiApp.PathProductApi}?CategoryId={categoryId}");
            var content = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
            var firstProduct = content!.FirstOrDefault();

            //Assert
            Assert.Equal(categoryExpected, firstProduct!.Category.Name);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task FiltrarProductosPorCategoria_CuandoCategoriaNoExiste_RetornaListaVacia()
        {
            //Arrange
            int categoryId = 120;

            //Act
            var response = await _client.GetAsync($"{apiApp.PathProductApi}?CategoryId={categoryId}");
            var content = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

            //Assert
            Assert.True(content!.Count == 0);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task FiltrarProductosPorRangoDePrecios_CuandoHayProductosEnElRango_RetornaProductosConPreciosEsperados()
        {
            //Arrange
            decimal priceMin = 80;
            decimal priceMax = 500;
            decimal firstPriceExpected = 89.99m;
            decimal secondPriceExpected = 400.00m;

            //Act
            var response = await _client.GetAsync($"{apiApp.PathProductApi}?MaxPrice={priceMax}&MinPrice={priceMin}");
            var content = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
            var firstProduct = content!.FirstOrDefault();
            var secondProduct = content!.ElementAt(1);

            //Assert
            Assert.Equal(firstPriceExpected, firstProduct!.Price);
            Assert.Equal(secondPriceExpected, secondProduct!.Price);
        }
    }
}
