using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Organic.Application.Command.User;
using Organic.Application.DTO;
using Organic.Application.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResultDto>
    {
        private readonly IUserQueryRepository _crudUserRepository;

        private readonly IJwtService _jwtService;


        public LoginUserCommandHandler(IUserQueryRepository crudUserRepository, IJwtService jwtService)
        {
            _crudUserRepository = crudUserRepository;

            _jwtService = jwtService;
        }

        public async Task<LoginResultDto> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var userExsitst = await _crudUserRepository.GetByPhoneNumberAndPasswordAsync(command.PhoneNumber, command.Password);

            if (userExsitst == null)
            {
                throw new Exception("User Not Found");
            }

            var result = new LoginResultDto
            {
                Token = await _jwtService.GeneratToken(userExsitst.Id)
            };

            return result;
        }
    }
}
