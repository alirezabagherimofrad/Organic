using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.User;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenricCommandRepository<AddressModel> _AddressCommandRepository;
        private readonly IGenricQueryRepository<AddressModel> _AddressQueryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateAddressCommandHandler(IUnitOfWork unitOfWork, IGenricCommandRepository<AddressModel> addressCommandRepository,
            IGenricQueryRepository<AddressModel> addressQueryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _AddressCommandRepository = addressCommandRepository;
            _AddressQueryRepository = addressQueryRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return "کاربر احراز هویت نشده است.";

            var user = await _AddressQueryRepository.GetByIdAsync(request.AddressId);
            if (user == null)
            {
                return "آدرس یافت نشد.";
            }

            user.UpdateAddress(request.City, request.FullAddress, request.PostalCode);
            await _AddressCommandRepository.Update(user);
            await _unitOfWork.SaveChangeAsync();
            return "با موفقیت اپدیت شد.";
        }
    }
}
