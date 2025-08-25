using Organic.Domain.Model.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.DTO
{
    public class SendInformationDTO
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
    }
}
