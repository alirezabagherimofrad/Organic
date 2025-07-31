using MediatR;
using Organic.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.Order
{
    public class AddOrderCommand : IRequest<string>
    {
        public ICollection<OrderItemModel> orderItemModels { get; set; }
    }
}
