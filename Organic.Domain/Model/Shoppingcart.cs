using Organic.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model
{
    public class Shoppingcart 
    {
        public string Id { get; private set; }
        public List<OrderItemModel> orderItemModels { get; private set; }
        public Guid UserId { get; private set; }
        public decimal FinalPrice { get; private set; }
        public DateTime CreadBasket { get; private set; }
    }
}
