using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.Infra.Data.Configurations
{
    public class OrderDetailModelConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("DetallePedido");

            builder.HasKey(orderDetail => new { orderDetail.OrderId, orderDetail.ProductId });

            builder.Property(orderDetail => orderDetail.Quantity)
                .IsRequired()
                .HasColumnName("Cantidad");

            builder.Property(orderDetail => orderDetail.ProductId)
                .HasColumnName("IdProducto")
                .IsRequired();

            builder.HasOne(orderDetail => orderDetail.Product)
                .WithMany(product => product.OrderDetails)
                .HasForeignKey(orderDetail => orderDetail.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(orderDetail => orderDetail.Order)
                .WithMany(order => order.OrderDetails)
                .HasForeignKey(orderDetail => orderDetail.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
