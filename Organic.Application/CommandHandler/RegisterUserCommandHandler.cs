
using Mapster;
using MediatR;
using Organic.Application.Command.User;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model;


namespace Organic.Application.CommandHandler
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
            var check = await _unitOfWork.UserQueryRepository().GetByPassword(request.Password);
            if(check != null)
            {
                return "رمز عبور تکراری هست.";
            }
            var user = request.Adapt<UserModel>();
            await _unitOfWork.CommandRepository<UserModel>().Add(user);
            await _unitOfWork.SaveChangeAsync();
            return user.Id.ToString();
        }
    }
}
