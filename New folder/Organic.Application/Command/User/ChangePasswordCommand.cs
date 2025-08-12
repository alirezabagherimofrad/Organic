using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class ChangePasswordCommand : IRequest<string>
    {
        public string Otp { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
