using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic.Application.Command;
using Organic.Application.Command.Message;
using Organic.Application.Command.MessageCommand;
using Organic.Application.Command.User;
using static Organic.Application.DTO.complete_informationDTO;
using static Organic.Application.DTO.LoginResultDto;
using static Organic.Application.DTO.UpdateRegisterDTO;

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

        [HttpPost("complete_information")]
        public async Task<IActionResult> complete_information([FromBody] complete_informationParameter complete_InformationParameter)
        {
            var command = complete_InformationParameter.Adapt<complete_informationCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> signup([FromBody]RegisterUserCommand registerUserCommand)
        {
            //var command = registerUserCommand.Adapt(registerUserCommand);
            var result = await _mediator.Send(registerUserCommand);
            return Ok(result);
        }

        [HttpPost("singinwhitotp")]
        public async Task<IActionResult> singinwhitotp([FromBody] RegisterWhitOtpCommand registerWhitOtpCommand)
        {
            //var command = registerUserCommand.Adapt(registerUserCommand);
            var result = await _mediator.Send(registerWhitOtpCommand);
            return Ok(result);
        }


        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdtaeUser([FromBody] UpdateUserParameter updateuserParameter)
        {
            var command = updateuserParameter.Adapt<UpdateRegisterCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand loginUserCommand)
        {
            var result = await _mediator.Send(loginUserCommand);
            return Ok(result);
        }

        [HttpPost("request_otp")]
        public async Task<IActionResult> LoginUser([FromBody] RequestOtpCommand requestOtpCommand)
        {
            var result = await _mediator.Send(requestOtpCommand);
            return Ok(result);
        }

        [HttpPut("forget_password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand forgetPasswordCommand)
        {
            var result = await _mediator.Send(forgetPasswordCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("change_password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePasswordCommand)
        {
            var result = await _mediator.Send(changePasswordCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("upload_image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] UplodeUserImageCommand uplodeUserImageCommand)
        {
            var result = await _mediator.Send(uplodeUserImageCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("add_address")]
        public async Task<IActionResult> AddAddress([FromBody] AddAddressCommand addAddressCommand)
        {
            var result = await _mediator.Send(addAddressCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("update_address")]
        public async Task<IActionResult> UpdateDatabase([FromBody] UpdateAddressCommand updateAddressCommand)
        {
            var result = await _mediator.Send(updateAddressCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("send_message")]
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

        //[Authorize]
        [HttpPost("faviorit")]
        public async Task<IActionResult> Faviorit([FromBody] FavoriteslistCommand favoriteslistCommand)
        {
            var result = await _mediator.Send(favoriteslistCommand);
            return Ok(result);
        }
    }
}
