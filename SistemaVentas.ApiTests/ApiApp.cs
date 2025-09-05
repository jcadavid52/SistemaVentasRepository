using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaVentas.Domain.Models;
using SistemaVentas.Infra.Data;

namespace SistemaVentas.ApiTests
{
    public class ApiApp:WebApplicationFactory<Program>
    {
        public string PathProductApi { get; } = "/api/product";
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<DataContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDb");
                });

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();
                SeedTestData(db);
            });

        }

        private static void SeedTestData(DataContext db)
        {
            var tecnology = Category.Create("Tecnología");
            var clothes = Category.Create("Ropa");
            var books = Category.Create("Libros");
            var cosmetics = Category.Create("Cosméticos");
            var home = Category.Create("Hogar");

            var product1 = Product.Create("Camiseta Nike", 89.99m, 50, 2);
            var product2 = Product.Create("Juego de Sábanas Queen", 400.00m, 20, 5);
            var product3 = Product.Create("Sofá Reclinable", 2500.00m, 10, 5);

            db.Categories.AddRange(
                tecnology,
                clothes,
                books,
                cosmetics,
                home
            );

            db.Products.AddRange(
                product1,
                product2,
                product3
            );

            db.SaveChanges();
        }
    }
}
