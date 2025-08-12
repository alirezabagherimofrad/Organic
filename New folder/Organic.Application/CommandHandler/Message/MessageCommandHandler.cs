using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.MessageCommand;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Address;
using Organic.Domain.Model.Message;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.Message
{
    public class MessageCommandHandler : IRequestHandler<MessageCommand, string>
    {
        private readonly IGenricCommandRepository<Point_of_viewModel> _messagecommandrepository;
        private readonly IGenricQueryRepository<UserModel> _messagequeryrepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public MessageCommandHandler(IGenricCommandRepository<Point_of_viewModel> addressCommandRepository, 
            IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IGenricQueryRepository<UserModel> addressqueryrepository)
        {
            _messagecommandrepository=addressCommandRepository;
            _httpContextAccessor=httpContextAccessor;
            _unitOfWork=unitOfWork;
            _messagequeryrepository=addressqueryrepository;
        }

        public async Task<string> Handle(MessageCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return "کاربر احراز هویت نشده است.";

            var userid = Guid.Parse(currentUserId);
            var user = await _messagequeryrepository.GetByIdAsync(userid);
            if (user == null)
            {
                return "کاربر یافت نشد.";
            }

            var message = request.Adapt<Point_of_viewModel>();
            if (user.Email != message.Email)
            {
                return "ایمیل وارد شده با ایمیل کاربر یکسان نیست.";
            }

            await _messagecommandrepository.Add(message);
            await _unitOfWork.SaveChangeAsync();
            return "پیام ثبت شد.";
        }
    }
}
