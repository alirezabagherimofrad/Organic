using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.User;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class ChangePasswordCommandHnadler : IRequestHandler<ChangePasswordCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenricQueryRepository<UserModel> _genricQueryRepository;

        public ChangePasswordCommandHnadler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IGenricQueryRepository<UserModel> genricQueryRepository)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _genricQueryRepository = genricQueryRepository;
        }

        public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return "کاربر احراز هویت نشده است.";

            var userId = Guid.Parse(currentUserId);
            var user = await _genricQueryRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return "کاربر با این شناسه یافت نشد.";
            }

            if(user.Password != request.OldPassword)
            {
                return "رمز فعلی اشتباه است.";
            }

            if(user.Password != request.Repeat_password)
            {
                return "تکرار رمز عبور جدید اشتباه است.";
            }
            user.SetNewPassword(request.NewPassword);
            await _unitOfWork.SaveChangeAsync();
            return "رمز عبور با موفقیت تغییر کرد.";
        }
    }
}
