using SistemaVentas.Domain.Abstractions;
using SistemaVentas.Domain.Common;
using SistemaVentas.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace SistemaVentas.Domain.Models
{
    public class Client:DomainEntity<int>
    {
        const int MaxQuatityOrderCancelledByClient = 3;

        public string Name { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public string Address { get; private set; } = default!;

        public ICollection<Order> Orders { get; private set; } = [];

        public static Client Create(string name, string email,string phoneNumber,string address)
        {
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Número de teléfono debe contener 10 caracteres y solo debe contener números");
            }

            return new Client
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };
        }

        public void CheckCancelledOrdersByClient()
        {
            var ordersCancelledByClient = Orders.Where(o => o.Status == "Cancelado").Count();

            if (ordersCancelledByClient > MaxQuatityOrderCancelledByClient)
            {
                throw new BusinessException($"El cliente no puede hacer más pedidos ya que tiene más de {MaxQuatityOrderCancelledByClient} en estado cancelado");
            }
        }

        private static bool IsValidPhoneNumber(string phoneNumber) => Regex.IsMatch(phoneNumber, ClientRegularExpressions.PhoneNumber);
    }
}
