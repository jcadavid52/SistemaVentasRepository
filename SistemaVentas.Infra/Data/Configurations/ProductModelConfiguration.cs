using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.Infra.Data.Configurations
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Productos");

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Id)
                .HasColumnName("IdProducto")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(product => product.Name)
                .HasColumnName("NombreProducto")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(product => product.Price)
                .HasColumnName("Precio")
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(product => product.Stock)
                .HasColumnName("Existencia")
                .IsRequired();

            builder.Property(product => product.CategoryId)
                .HasColumnName("IdCategoria");

            builder.Property(product => product.CreatedAt)
                .HasColumnName("FechaCreacion");

            builder.HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(product => product.OrderDetails)
                .WithOne(orderDetail => orderDetail.Product)
                .HasForeignKey(orderDetail => orderDetail.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
