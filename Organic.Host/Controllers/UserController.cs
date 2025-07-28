using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command.User;
using Organic.Application.DTO;
using static Organic.Application.DTO.LoginResultDto;
using static Organic.Application.DTO.UpdateRegisterDTO;
using static Organic.Application.DTO.UserRegisterDTO;

namespace Organic.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterParameter userRegisterParameter)
        {
            var command = userRegisterParameter.Adapt<RegisterUserCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdtaeUser([FromBody] UpdateUserParameter updateuserParameter)
        {
            var command = updateuserParameter.Adapt<UpdateRegisterCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand loginUserCommand)
        {
            var result = await _mediator.Send(loginUserCommand);
            return Ok(result);
        }

        //[HttpPut("Change_Password")]
        //public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand loginUserCommand)
        //{
        //    var result = await _mediator.Send(loginUserCommand);
        //    return Ok(result);
        //}
    }
}
