using SistemaVentas.App.Dtos;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.App.Extensions
{
	public static class OrderExtension
	{
		public static List<OrderDetail> BuildOrderDetail(List<OrderDetailRequestDto> items)
		{
			var orderDetails = new List<OrderDetail>();
			foreach (var item in items)
			{
				var orderDetail = OrderDetail.Create(
					item.Quantity,
					item.ProductId
				);

				orderDetails.Add(orderDetail);
			}
			return orderDetails;
		}

		public static List<OrderDto> ToOrdersDto(this List<Order> orders)
		{
			var ordersDto = new List<OrderDto>();

			ordersDto = orders
				.Select(order =>
				new OrderDto(
					order.Id,
					order.Status,
					order.CreatedAt,
					new ClientDto(
						order.Client.Id,
						order.Client.Name,
						order.Client.Email,
						order.Client.PhoneNumber,
						order.Client.Address
					),
					order.OrderDetails
						.Select(orderDetail =>
							new OrderDetailDto(
								orderDetail.Quantity,
								new ProductDto(
									orderDetail.Product.Id,
									orderDetail.Product.Name,
									orderDetail.Product.Price,
									orderDetail.Product.Stock,
									new CategoryDto(
										orderDetail.Product.Category.Id,
										orderDetail.Product.Category.Name
									)
								)
							)
						).ToList()
				)
			).ToList();

			return ordersDto;
		}

		public static InvoiceDto ToInvoiceDto(
			this Order order,
			Invoice invoice
			)
		{
			var invoiceDto = new InvoiceDto(
				invoice.Id,
				invoice.InvoiceNumber,
				invoice.Iva,
				invoice.Subtotal,
				invoice.Total,
				invoice.OrderId,
				invoice.CreatedAt,
                order.OrderDetails.Select(o =>
				new OrderDetailDto(
					o.Quantity,
					new ProductDto(
						o.Product.Id,
						o.Product.Name,
						o.Product.Price,
						o.Product.Stock,
						new CategoryDto(
							o.Product.Category.Id,
							o.Product.Category.Name
							)
						)

				)).ToList(),
				new ClientDto(
                    order.Client.Id,
                    order.Client.Name,
                    order.Client.Email,
                    order.Client.PhoneNumber,
                    order.Client.Address
                )
			);

			return invoiceDto;

        }
	}
}
