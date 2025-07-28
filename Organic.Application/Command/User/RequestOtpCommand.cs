using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class RequestOtpCommand : IRequest<string>
    {
        public string PhoneNumber { get; set; }
    }
}
