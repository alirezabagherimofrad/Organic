using MediatR;
using Organic.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class LoginUserCommand : IRequest<LoginResultDto>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
