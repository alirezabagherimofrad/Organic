using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.DTO
{
    public class UserRegisterDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string PhoneNumber { get; set; }

        public sealed record UserRegisterParameter
            (
                string First_Name,
                string Last_Name,
                string PhoneNumber
            );
    }

}
