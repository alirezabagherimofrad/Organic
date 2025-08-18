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
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public string RepetitionPassword { get; set; }
    }
}
