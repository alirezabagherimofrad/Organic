
using Mapster;
using MediatR;
using Organic.Application.Command.User;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;


namespace Organic.Application.CommandHandler.UserHandler
{
    public class complete_informationCommandHandler : IRequestHandler<complete_informationCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenricCommandRepository<UserModel> _userRepository;
        public complete_informationCommandHandler (IUnitOfWork unitOfWork, IGenricCommandRepository<UserModel> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(complete_informationCommand request, CancellationToken cancellationToken)
        {
            var check = await _unitOfWork.UserQueryRepository().GetByEmail(request.Email);
            if(check != null)
            {
                return "ایمیل تکراری است.";
            }
            var user = request.Adapt<UserModel>();
            await _userRepository.Add(user);
            await _unitOfWork.SaveChangeAsync();
            return user.Id.ToString();
        }
    }
}
