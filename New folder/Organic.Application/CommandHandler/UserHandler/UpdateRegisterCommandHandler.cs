using Mapster;
using MediatR;
using Organic.Application.Command.User;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class UpdateRegisterCommandHandler : IRequestHandler<UpdateRegisterCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenricQueryRepository<UserModel> _genricQueryRepository;
        private readonly IGenricCommandRepository<UserModel> _genricCommandRepository;
        public UpdateRegisterCommandHandler(IUnitOfWork unitOfWork, IGenricQueryRepository<UserModel> genricQueryRepository, IGenricCommandRepository<UserModel> genricCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _genricCommandRepository = genricCommandRepository;
            _genricQueryRepository = genricQueryRepository;
        }

        public async Task<bool> Handle(UpdateRegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _genricQueryRepository.GetByIdAsync(request.Id);
            if (existingUser == null)
            {
                return false;
            }
            existingUser.update(request.First_Name, request.Last_Name, request.PhoneNumber, request.Email, request.Password, request.Gender);
            await _genricCommandRepository.Update(existingUser);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
