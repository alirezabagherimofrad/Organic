using Mapster;
using MediatR;
using Organic.Application.Command.User;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetUserQueryRepository _getUserQueryRepository;
        public ForgetPasswordCommandHandler(IUnitOfWork unitOfWork, IGetUserQueryRepository getUserQueryRepository)
        {
            _unitOfWork = unitOfWork;
            _getUserQueryRepository = getUserQueryRepository;
        }

        public async Task<string> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _getUserQueryRepository.GetByEmail(request.Email);
            if(user == null)
            {
                return "ایمیل وارد شده یافت نشد.";
            }

            //if (user.Otp != request.Otp || user.OtpExpiry < DateTime.UtcNow)
            //{
            //    return "کد تایید معتبر نیست.";
            //}

            var otp = new Random().Next(100000, 999999).ToString();
            var OtpExpiry = DateTime.UtcNow.AddMinutes(10);

            //user.SetNewPassword(request.NewPassword);
            user.SetOtp(otp, OtpExpiry);
            await _unitOfWork.SaveChangeAsync();
            return "کد یکبار مصرف برای شما ارسال شد.";
        }
    }
}
