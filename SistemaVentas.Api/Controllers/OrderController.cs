using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.App.OrderUseCases.Cancel;
using SistemaVentas.App.OrderUseCases.Create;
using SistemaVentas.App.OrderUseCases.Filter;
using SistemaVentas.App.OrderUseCases.Pay;

namespace SistemaVentas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Filter([FromQuery] FilterOrderQuery query)
        {
            var orders = await mediator.Send(query);

            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var id = await mediator.Send(command);

            var uri = $"order/api/get-by-id/{id}";

            return Created(uri, new { id });
        }

        [HttpPost("{id}/cancel")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Cancel(int id)
        {
            var messsageCancel = await mediator.Send(new CancelOrderCommand(id));

            return Ok(messsageCancel);
        }
        [HttpPost("{orderId}/pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Pay(int orderId, [FromBody] PayOrderCommand command)
        {
            command = command with { OrderId = orderId };

            var invoice = await mediator.Send(command);

            return Ok(invoice);
        }

    }
}
