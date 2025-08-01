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
            var user = await _getUserQueryRepository.GetByPhoneNumber(request.PhoneNumber);
            if(user == null)
            {
                return "شماره موبایل یافت نشد.";
            }

            if (user.Otp != request.Otp || user.OtpExpiry < DateTime.UtcNow)
            {
                return "کد تایید معتبر نیست.";
            }

            user.SetNewPassword(request.NewPassword);
            await _unitOfWork.SaveChangeAsync();
            return "تغییر رمز عبور با موفقیت انجام شد.";
        }
    }
}
