using MediatR;
using Organic.Application.Command.User;
using Organic.Domain.Interface.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class RequestOtpCommandHandler : IRequestHandler<RequestOtpCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestOtpCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(RequestOtpCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserQueryRepository().GetByPhoneNumber(request.PhoneNumber);
            if(user == null)
            {
                return "کاربری یافت نشد.";
            }
            var otp = new Random().Next(100000, 999999).ToString();
            var OtpExpiry = DateTime.UtcNow.AddMinutes(10);

            user.SetOtp(otp, OtpExpiry);
            await _unitOfWork.SaveChangeAsync();
            return "رمز عبور یکبار مصرف ارسال شد.";
        }
    }
}
