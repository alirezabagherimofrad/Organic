using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model
{
    public class UserModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string NationalCode { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public SelectGender Gender { get; private set; }

        public UserImageModel Image { get; private set; }
    }
    public enum SelectGender
    {
        [Display(Name = "Man")]
        Man,

        [Display(Name = "Woman")]
        Woman
    }
}
