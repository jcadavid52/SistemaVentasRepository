using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.Infra.Data.Configurations
{
    public class CategoryModelConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(category => category.Id);

            builder.Property(category => category.Id)
                .HasColumnName("IdCategoria")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(category => category.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(category => category.CreatedAt)
                .HasColumnName("FechaCreacion");

            builder.HasMany(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
