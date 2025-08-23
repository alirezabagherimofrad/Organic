using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command;
using Organic.Application.DTO;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler
{
    public class SendInformationCommandHandler : IRequestHandler<SendInformationCommand, SendInformationResult>
    {
        private readonly IGenricQueryRepository<UserModel> _genricQueryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public SendInformationCommandHandler(IGenricQueryRepository<UserModel> genricQueryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _genricQueryRepository=genricQueryRepository;
            _httpContextAccessor=httpContextAccessor;
        }

        public async Task<SendInformationResult> Handle(SendInformationCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return new SendInformationResult
                {
                    User = null,
                    Message = "کاربر احراز هویت نشده است."
                };
            var userid = Guid.Parse(currentUserId);
            if (userid == null)
            {
                return new SendInformationResult
                {
                    User = null,
                    Message = "کاربر یافت نشد."
                };
            }
            var user = await _genricQueryRepository.GetByIdAsync(userid);
            
            user.sendorderinformation(request.Address, request.Email, request.Phonenumber);
            await _unitOfWork.SaveChangeAsync();
            return new SendInformationResult
            {
                User = user,
                Message = "کاربر احراز هویت نشده است."
            };
        }
    }
}
