using MediatR;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.Product;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model.Product;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.ProductHandler
{
    public class FavoriteslistCommandHandler : IRequestHandler<FavoriteslistCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenricCommandRepository<FavoriteslistModel> _FavoritCommandRepository;
        private readonly IGenricQueryRepository<UserModel> _UserQueryRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IfavoriteslistQueryRepository _favoriteslistQueryRepository;

        public FavoriteslistCommandHandler(IUnitOfWork unitOfWork, IGenricCommandRepository<FavoriteslistModel> favoritCommandRepository,
            IGenricQueryRepository<UserModel> favoritQueryRepository, IHttpContextAccessor contextAccessor, IfavoriteslistQueryRepository favoriteslistQueryRepository)
        {
            _unitOfWork=unitOfWork;
            _FavoritCommandRepository=favoritCommandRepository;
            _UserQueryRepository=favoritQueryRepository;
            _contextAccessor=contextAccessor;
            _favoriteslistQueryRepository = favoriteslistQueryRepository;
        }

        public async Task<string> Handle(FavoriteslistCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _contextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return "کاربر احراز هویت نشده است.";

            var userId = Guid.Parse(currentUserId);
            var user = await _UserQueryRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return "کاربر یافت نشد.";
            }

            var product = await _favoriteslistQueryRepository.favoriteslist(userId, request.ProductId);
            if (product == null)
            {
                await _FavoritCommandRepository.Add(product);
                await _unitOfWork.SaveChangeAsync();
                return "کالا در فهرست علاقه مندی ها قرار گرفت.";
            }
            await _FavoritCommandRepository.Delete(product);
            await _unitOfWork.SaveChangeAsync();
            return "کالای مورد نظر از فهرست کالا های مورد علاقه حذف شد.";
        }
    }
}
