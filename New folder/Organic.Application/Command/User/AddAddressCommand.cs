using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class AddAddressCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }

    }
}
