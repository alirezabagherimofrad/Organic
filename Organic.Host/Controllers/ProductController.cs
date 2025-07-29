using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command.Product;

namespace Organic.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductCommand Command)
        {
            var result = await _mediator.Send(Command);

            return Ok(result);
        }
    }
}
