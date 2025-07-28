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
        public UserModel(string first_Name, string last_Name, string phoneNumber, string email, string password, SelectGender gender)
        {
            Id = Guid.NewGuid();
            First_Name = first_Name;
            Last_Name = last_Name;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public Guid Id { get; private set; }
        public string First_Name { get; private set; }
        public string Last_Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public SelectGender Gender { get; private set; }
        public string? Otp { get; private set; } 
        public DateTime? OtpExpiry { get; private set; }

        public UserImageModel Image { get; private set; }

        private  UserModel() { }

        public  void update(string first_Name, string last_Name, string phoneNumber, string email, string password, SelectGender gender)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public void SetOtp(string? otp, DateTime? otpExpiry)
        {
            Otp = otp;
            OtpExpiry = otpExpiry;
        }
    }
    public enum SelectGender
    {
        [Display(Name = "Man")]
        Man,

        [Display(Name = "Woman")]
        Woman
    }


}
