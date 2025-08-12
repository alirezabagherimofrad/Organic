using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.User
{
    public class UpdateAddressCommand : IRequest<string>
    {
        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
    }
}
