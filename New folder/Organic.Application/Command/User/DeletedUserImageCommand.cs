using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class DeletedUserImageCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
