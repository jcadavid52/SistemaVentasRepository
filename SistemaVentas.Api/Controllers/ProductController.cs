using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.App.ProductUseCases.Create;
using SistemaVentas.App.ProductUseCases.Filter;
using SistemaVentas.App.ProductUseCases.UpdateStock;

namespace SistemaVentas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Filter([FromQuery] FilterProductQuery query)
        {
            var products = await mediator.Send(query);

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand command)
        {
            var id = await mediator.Send(command);

            return Created("", new { id });
        }

        [HttpPut("{id}/stock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStock(int id,[FromBody] UpdateStockProductCommand command)
        {
            command = command with { Id = id };
            var product = await mediator.Send(command);

            return Ok(product);
        }
    }
}
