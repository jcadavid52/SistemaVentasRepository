using Microsoft.EntityFrameworkCore;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.Infra.Data
{
    public class DataContext(DbContextOptions options):DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var tecnology = Category.Create("Tecnología");
            tecnology.Id = 1;

            var clothes = Category.Create("Ropa");
            clothes.Id = 2;

            var books = Category.Create("Libros");
            books.Id = 3;

            var cosmetics = Category.Create("Cosméticos");
            cosmetics.Id = 4;

            var home = Category.Create("Hogar");
            home.Id = 5;

            builder.Entity<Category>().HasData(
                tecnology,
                clothes,
                books,
                cosmetics,
                home
            );

            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
