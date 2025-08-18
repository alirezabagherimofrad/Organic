using FluentValidation;
using Organic.Application.Command.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Validators.UserValidation
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidation()
        {
            RuleFor(x => x.Phonenumber)
                        .NotEmpty()
                        .MaximumLength(15)
                        .WithMessage("شماره تلفن نباید بیشتر از ۱۵ کاراکتر باشد.");
        }
    }
}
