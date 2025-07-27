using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
    }
}
