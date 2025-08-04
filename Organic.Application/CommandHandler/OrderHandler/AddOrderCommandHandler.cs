//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Organic.Application.Command.Order;
//using Organic.Domain.Interface;
//using Organic.Domain.Model.Order;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Organic.Application.CommandHandler.OrderHandler
//{
//    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, string>
//    {
//        private readonly IGenricCommandRepository<OrderItemModel> _CommandRepository;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public AddOrderCommandHandler(IGenricCommandRepository<OrderItemModel> commandRepository, IHttpContextAccessor httpContextAccessor)
//        {
//            _CommandRepository = commandRepository;
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public async Task<string> Handle(AddOrderCommand request, CancellationToken cancellationToken)
//        {
//            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
//            if (string.IsNullOrEmpty(currentUserId))
//                return "کاربر احراز هویت نشده است.";

//            var userId = Guid.Parse(currentUserId);


//        }
//    }
//}
