using MediatR;
using Organic.Application.DTO;
using Organic.Domain.Model.Address;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command
{
    public class SendInformationCommand : IRequest<SendInformationResult>
    {
        public List<AddressModel> Address { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
    }
}
