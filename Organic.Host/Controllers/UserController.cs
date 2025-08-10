using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command.Message;
using Organic.Application.Command.MessageCommand;
using Organic.Application.Command.User;
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

        [Authorize]
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

        [HttpPost("Request_Otp")]
        public async Task<IActionResult> LoginUser([FromBody] RequestOtpCommand requestOtpCommand)
        {
            var result = await _mediator.Send(requestOtpCommand);
            return Ok(result);
        }

        [HttpPut("Forget_Password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand forgetPasswordCommand)
        {
            var result = await _mediator.Send(forgetPasswordCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("Change_Password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePasswordCommand)
        {
            var result = await _mediator.Send(changePasswordCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Upload_Image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] UplodeUserImageCommand uplodeUserImageCommand)
        {
            var result = await _mediator.Send(uplodeUserImageCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Add_Address")]
        public async Task<IActionResult> AddAddress([FromBody]AddAddressCommand addAddressCommand)
        {
            var result = await _mediator.Send(addAddressCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("Update_Address")]
        public async Task<IActionResult>  UpdateDatabase([FromBody] UpdateAddressCommand updateAddressCommand)
        {
            var result = await _mediator.Send(updateAddressCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Send_message")]
        public async Task<IActionResult> sendmessage([FromBody] MessageCommand messageCommand)
        {
            var result = await _mediator.Send(messageCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("message")]
        public async Task<IActionResult> message([FromBody] Point_of_viewCommand point_Of_ViewCommand)
        {
            var result = await _mediator.Send(point_Of_ViewCommand);
            return Ok(result);
        }

    }
}
