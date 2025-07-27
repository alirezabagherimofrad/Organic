using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.DTO
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }

        public sealed record UserRegisterParameter
            (
                string Name,
                string PhoneNumber,
                string NationaCode
            );
    }

}
