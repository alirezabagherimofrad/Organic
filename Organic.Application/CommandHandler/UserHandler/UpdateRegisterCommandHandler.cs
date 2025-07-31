using Mapster;
using MediatR;
using Organic.Application.Command.User;
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
        public UpdateRegisterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateRegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.UserQueryRepository().GetById(request.Id);
            if (existingUser == null)
            {
                return false;
            }
            existingUser.update(request.First_Name, request.Last_Name, request.PhoneNumber, request.Email, request.Password, request.Gender);
            await _unitOfWork.CommandRepository<UserModel>().Update(existingUser);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
