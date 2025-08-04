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
        public AddBasketCommandHandler(IGenricCommandRepository<Basket> basketCommandRepository, IGenricQueryRepository<Basket> baskeyQueryRepository, 
            IGenricQueryRepository<UserModel> userQueryRepository, IUnitOfWork unitOfWork)
        {
            _BasketCommandRepository = basketCommandRepository;
            _BasketQueryRepository = _BasketQueryRepository;
            _UserQueryRepository = userQueryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(AddBasketCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserQueryRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                //basket = new Basket(request.UserId);
                //await _genricCommandRepository.Add(basket);
                throw new Exception("User not found");
            }

            var basket = await _BasketQueryRepository.GetByIdAsync(request.UserId);
            if (basket == null)
            {
                basket = new Basket(request.UserId);
                await _BasketCommandRepository.Add(basket);
            }

            foreach (var itemDto in request.Items)
            {
                var item = new BasketItemModel(itemDto.ProductId, itemDto.Quantity, itemDto.UnitPrice);
                basket.AddItem(item);
            }

            await _BasketCommandRepository.Update(basket);
            await _unitOfWork.SaveChangeAsync();

            return "Basket updated successfully.";
        }
    }
}
