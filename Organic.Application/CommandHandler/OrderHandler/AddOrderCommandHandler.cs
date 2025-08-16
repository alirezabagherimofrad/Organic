using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.Order;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.OrderHandler
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, string>
    {
        private readonly IGenricCommandRepository<OrderItemModel> _CommandRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrderCommandHandler(IGenricCommandRepository<OrderItemModel> commandRepository, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _CommandRepository = commandRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            //var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            //if (string.IsNullOrEmpty(currentUserId))
            //    return "کاربر احراز هویت نشده است.";


            var Add = request.Adapt<OrderItemModel>();
            await _CommandRepository.Add(Add);
            await _unitOfWork.SaveChangeAsync();
            return "Successful";

        }
    }
}
