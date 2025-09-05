using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.Infra.Data.Configurations
{
    public class InvoiceModelConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Factura");

            builder.HasKey(invoice => invoice.Id);

            builder.Property(invoice => invoice.Id)
                .HasColumnName("IdFactura")
                .IsRequired();

            builder.Property(invoice => invoice.InvoiceNumber)
                .HasColumnName("NumeroFactura")
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(invoice => invoice.Iva)
                .HasColumnName("Iva")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(invoice => invoice.Subtotal)
                .HasColumnName("Subtotal")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(invoice => invoice.Total)
                .HasColumnName("Total")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(invoice => invoice.OrderId)
                .HasColumnName("IdPedido")
                .IsRequired();

            builder.Property(invoice => invoice.CreatedAt)
                .HasColumnName("FechaCreacion")
                .IsRequired();

            builder.HasOne(invoice => invoice.Order)
                .WithMany(order => order.Invoices)
                .HasForeignKey(invoice => invoice.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
