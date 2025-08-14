using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command.Product;
using Organic.Application.CommandHandler.ProductHandler;

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

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand Commad)
        {
            var result = await _mediator.Send(Commad);

            return Ok(result);
        }

        [HttpPatch("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand updateProductCommand)
        {
            var result = await _mediator.Send(updateProductCommand);

            return Ok(result);
        }

    }
}
