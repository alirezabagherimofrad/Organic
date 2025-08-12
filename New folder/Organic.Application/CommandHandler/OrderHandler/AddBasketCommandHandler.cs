using MediatR;
using Organic.Application.Command.Order;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model.Order;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.OrderHandler
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommand, string>
    {
        private readonly IGenricCommandRepository<Basket> _BasketCommandRepository;
        private readonly IGenricQueryRepository<Basket> _BasketQueryRepository;
        private readonly IGenricQueryRepository<UserModel> _UserQueryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _BasketRepository;
        public AddBasketCommandHandler(IGenricCommandRepository<Basket> basketCommandRepository, IGenricQueryRepository<Basket> baskeyQueryRepository,
            IGenricQueryRepository<UserModel> userQueryRepository, IUnitOfWork unitOfWork, IBasketRepository basketRepository)
        {
            _BasketCommandRepository = basketCommandRepository;
            _BasketQueryRepository = baskeyQueryRepository;
            _UserQueryRepository = userQueryRepository;
            _unitOfWork = unitOfWork;
            _BasketRepository=basketRepository;
        }

        public async Task<string> Handle(AddBasketCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserQueryRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found");

            var basket = await _BasketRepository.basketwhitUserId(request.UserId);

            if (basket == null)
            {
                basket = new Basket(request.UserId);
                foreach (var itemDto in request.Items)
                {
                    var item = new BasketItemModel(itemDto.ProductId, itemDto.Quantity, itemDto.UnitPrice);
                    basket.AddItem(item);
                }
                await _BasketCommandRepository.Add(basket);
                await _unitOfWork.SaveChangeAsync();
                return "Basket created and items added.";
            }
            else
            {
                foreach (var itemDto in request.Items)
                {
                    var existingItem = basket.basketItemModels
                                             .FirstOrDefault(i => i.ProductId == itemDto.ProductId);

                    if (existingItem != null)
                    {
                        existingItem.UpdateQuantity(existingItem.Quantity + itemDto.Quantity);
                    }
                    else
                    {
                        var newItem = new BasketItemModel(itemDto.ProductId, itemDto.Quantity, itemDto.UnitPrice);

                        basket.AddItem(newItem);
                    }
                }
                await _BasketCommandRepository.Update(basket);

                await _unitOfWork.SaveChangeAsync();
                return "Basket updated successfully.";
            }
        }
    }
}
