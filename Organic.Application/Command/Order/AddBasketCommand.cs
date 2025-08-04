using MediatR;
using Organic.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.Order
{
    public class AddBasketCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
