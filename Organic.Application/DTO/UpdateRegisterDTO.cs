using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.DTO
{
    public class UpdateRegisterDTO
    {
        public Guid Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public SelectGender Gender { get; set; }

        public sealed record UpdateUserParameter
            (
                Guid Id,
                string First_Name,
                string Last_Name,
                string PhoneNumber,
                string Email,
                string Password,
                SelectGender Gender
            );
    }
}
