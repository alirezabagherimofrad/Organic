using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command.Product;

namespace Organic.Host.Controllers.ProductController
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductController2 : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController2(IMediator mediator)
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
