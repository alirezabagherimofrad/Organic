
using Mapster;
using MediatR;
using Organic.Application.Command.User;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;


namespace Organic.Application.CommandHandler.UserHandler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterUserCommandHandler (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var check = await _unitOfWork.UserQueryRepository().GetByEmail(request.Email);
            if(check != null)
            {
                return "ایمیل تکراری است.";
            }
            var user = request.Adapt<UserModel>();
            await _unitOfWork.CommandRepository<UserModel>().Add(user);
            await _unitOfWork.SaveChangeAsync();
            return user.Id.ToString();
        }
    }
}
