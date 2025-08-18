using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Organic.Application.Command.User;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenricCommandRepository<UserModel> _userRepository;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IGenricCommandRepository<UserModel> userRepository)
        {
            _unitOfWork=unitOfWork;
            _userRepository=userRepository;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.RepetitionPassword)
            {
                return "عدم تطابق رمز عبور با تکرار رمز عبور.";
            }
            var newUser = new UserModel
            (
                first_Name : string.Empty,
                last_Name : string.Empty,
                phoneNumber: request.Phonenumber,
                email: string.Empty,
                password: request.Password,
                gender: SelectGender.Man
            );

            var user = await _userRepository.Add(newUser);
            await _unitOfWork.SaveChangeAsync();
            return "successful";
        }
    }
}
