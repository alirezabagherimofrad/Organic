using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command.Order;

namespace Organic.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Basxet")]
        public async Task<IActionResult> Add([FromBody] AddBasketCommand addBasketCommand)
        {
            var command = await _mediator.Send(addBasketCommand);
            return Ok(command);
        }
    }
}
