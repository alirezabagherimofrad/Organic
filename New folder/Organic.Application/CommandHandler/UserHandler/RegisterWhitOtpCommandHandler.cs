using MediatR;
using Organic.Application.Command.User;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class RegisterWhitOtpCommandHandler : IRequestHandler<RegisterWhitOtpCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetUserQueryRepository _getUserQueryRepository;

        public RegisterWhitOtpCommandHandler(IUnitOfWork unitOfWork, IGetUserQueryRepository getUserQueryRepository)
        {
            _unitOfWork = unitOfWork;
            _getUserQueryRepository = getUserQueryRepository;
        }
        public async Task<string> Handle(RegisterWhitOtpCommand request, CancellationToken cancellationToken)
        {
            var user = await _getUserQueryRepository.GetByOtp(request.Otp);
            if (user.OtpExpiry < DateTime.Now)
            {
                return "رمز یک بار مصرف منقضی شده است.";
            }

            if (user.Otp == null)
            {
                return "کد یکبار مصرف وارد شده وجود ندارد";
            }
            return $"خوش آمدید {user.First_Name + "" + user.Last_Name}";
        }
    }
}
