using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.DTO
{
    public class RequestOtpCommand : IRequest<string>
    {
        public string PhoneNumber { get; set; }
    }
}
