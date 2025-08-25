using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.dashbord;
using Organic.Application.DTO;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Address;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.dashbord
{
    public class SendInformationCommandHandler : IRequestHandler<SendInformationCommand, SendInformationDTO>
    {
        private readonly IGenricQueryRepository<UserModel> _UserQueryRepository;
        private readonly IGenricQueryRepository<AddressModel> _AddressQueryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public SendInformationCommandHandler(IGenricQueryRepository<UserModel> userqueryrepository, IGenricQueryRepository<AddressModel> addressqueryrepository, IHttpContextAccessor httpContextAccessor)
        {
            _UserQueryRepository=userqueryrepository;
            _httpContextAccessor=httpContextAccessor;
            _AddressQueryRepository=addressqueryrepository;
        }

        public async Task<SendInformationDTO> Handle(SendInformationCommand request, CancellationToken cancellationToken)
        {
            //todo: change incomed model
            //use segeraegation concern-> get current user and the validation should be in another class
            //implement ur bussiness
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return null;
            var userid = Guid.Parse(currentUserId);
            if (userid == null)
            {
                return null;
            }
            var user = await _UserQueryRepository.GetByIdAsync(userid);
             
            if (_AddressQueryRepository == null)
            {
                Console.WriteLine("_AddressQueryRepository IS NULL");
            }
            var address = await _AddressQueryRepository.GetAllAsync(a => a.UserId == userid);

            if (address == null)
            {
                Console.WriteLine("addresses IS NULL");
            }
            else
            {
                Console.WriteLine("addresses.Count = " + address.Count);
            }
            //user.sendorderinformation(request.Address, request.Email, request.Phonenumber);
            // Mapster configuration
            //TypeAdapterConfig<UserModel, SendInformationDTO>.NewConfig()
            //    .Map(dest => dest.Phonenumber, src => src.PhoneNumber)
            //    .Map(dest => dest.Address, src =>
            //    {

            //    });

            //return user.Adapt<SendInformationDTO>();
            var currentAddress = address.FirstOrDefault(a => a.CurrentAddress);
            var result = new SendInformationDTO
            {
                Address = currentAddress.FullAddress,
                Phonenumber = user.PhoneNumber,
                Email = user.Email,
            };

            return result;
        }
    }
}
