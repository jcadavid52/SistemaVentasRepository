using SistemaVentas.Domain.Models;

namespace SistemaVentas.DomainTests.ModelsTests
{
    public class ClientTests
    {
        [Fact]
        public void CreateClient_NumeroTelefonoInvalido_DebeMostrarArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Client.Create(
                    "client tests",
                    "email@test.com",
                    "312711893x",
                    "calle 10"
                );
            });
        }
    }
}
