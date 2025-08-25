using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command.dashbord;

namespace Organic.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashbordController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DashbordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[Authorize]
        [HttpGet("informationsend")]
        public async Task<IActionResult> sendinformation()
        {
            var command = new SendInformationCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[Authorize]
        //[HttpGet("ShippinginformationEmail")]

    }
}
