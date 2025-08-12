using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.User;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Address;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, string>
    {
        private readonly IGenricCommandRepository<AddressModel> _AddressCommandRepository;
        private readonly IGenricQueryRepository<UserModel> _AddressQueryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public AddAddressCommandHandler(IGenricCommandRepository<AddressModel> addressCommandRepository, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IGenricQueryRepository<UserModel> addressQueryRepository)
        {
            _AddressCommandRepository = addressCommandRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _AddressQueryRepository = addressQueryRepository;
        }

        public async Task<string> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return "کاربر احراز هویت نشده است.";

            var userId = Guid.Parse(currentUserId);
            var user = await _AddressQueryRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return "کاربر یافت نشد.";
            }

            var address = new AddressModel(request.City, request.FullAddress, request.PostalCode, userId);
            await _AddressCommandRepository.Add(address);
            await _unitOfWork.SaveChangeAsync();
            return "ادرس با موفقیت ثبت شد.";

        }
    }
}
