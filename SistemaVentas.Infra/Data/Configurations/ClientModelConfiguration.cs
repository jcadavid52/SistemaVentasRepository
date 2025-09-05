using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.Infra.Data.Configurations
{
    public class ClientModelConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(client => client.Id);

            builder.Property(client => client.Id)
               .HasColumnName("IdCliente")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(client => client.Name)
                .HasColumnName("NombreCliente")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(client => client.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(client => client.PhoneNumber)
                .HasColumnName("Telefono")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(client => client.Address)
                .HasColumnName("Direccion")
                .IsRequired()
                .HasMaxLength(150);

            builder.HasMany(client => client.Orders)
                .WithOne(order => order.Client)
                .HasForeignKey(order => order.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
