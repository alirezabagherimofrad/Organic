using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class UplodeUserImageCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public IFormFile ImageFile { get; set; }
    } 
}
