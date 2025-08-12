using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.MessageCommand
{
    public class MessageCommand : IRequest<string>
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
