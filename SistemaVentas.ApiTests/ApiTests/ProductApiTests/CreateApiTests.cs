using SistemaVentas.ApiTests.DataBuilderApi;
using System.Net;
using System.Net.Http.Json;

namespace SistemaVentas.ApiTests.ApiTests.ProductApiTests
{
    public class CreateApiTests(ApiApp apiApp) : IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();
        private readonly ProductDataBuilder _productDataBuilder = new();

        [Fact]
        public async Task CrearProducto_CuandoSeCreaCorrectamente_RetornaStatus201()
        {
            //Arrange
            var command = _productDataBuilder.BuildCreateCommand();

            //Act
            var response = await _client.PostAsJsonAsync($"{apiApp.PathProductApi}", command);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Theory]
        [InlineData("Name")]
        [InlineData("Price")]
        [InlineData("Stock")]
        [InlineData("CategoryId")]
        public async Task CrearProducto_CuandoLosCamposSonInvalidos_RetornaStatusBadRequest(string invalidPropertyName)
        {
            //Arrange
            switch (invalidPropertyName)
            {
                case "Name":
                    _productDataBuilder.WithName("");
                break;
                case "Price":
                    _productDataBuilder.WithPrice(default);
                break;
                case "Stock":
                    _productDataBuilder.WithStock(default);
                break;
                case "CategoryId":
                    _productDataBuilder.WithCategoryId(default);
                break;
            }

            var command = _productDataBuilder.BuildCreateCommand();

            //Act
            var response = await _client.PostAsJsonAsync($"{apiApp.PathProductApi}", command);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
