using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.Infra.Data.Configurations
{
    public class OrderModelConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(order => order.Id);

            builder.Property(order => order.Id)
                .HasColumnName("IdPedido")
                .IsRequired();

            builder.Property(order => order.CreatedAt)
                .HasColumnName("FechaCreacion");

            builder.Property(order => order.Status)
                .HasColumnName("Estado")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(order => order.ClientId)
                .HasColumnName("IdCliente")
                .IsRequired();

            builder.HasOne(order => order.Client)
                .WithMany(client => client.Orders)
                .HasForeignKey(order => order.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(order => order.Invoices)
                .WithOne(invoice => invoice.Order)
                .HasForeignKey(invoice => invoice.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
