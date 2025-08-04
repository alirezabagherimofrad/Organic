using Organic.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Order
{
    public class OrderItemModel
    {
        private OrderItemModel() { }

        public Guid Id { get; private set; }

        public Guid OrderId { get; private set; }

        public OrderModel Order { get; private set; }

        public Guid ProductId { get; private set; }

        public ProductModel Product { get; private set; }

        public int Quantity { get; private set; }

        public int UnitPrice { get; private set; }

        public int TotalPrice => Quantity * UnitPrice;

        //public ICollection<OrderItemModel> OrderItems { get; private set; }

        public OrderItemModel(Guid orderId, /*OrderModel order,*/ Guid productId, ProductModel product)
        {
            Id = Guid.NewGuid();

            OrderId = orderId;

            ProductId = productId;

            Product = product;

            //OrderItems = new List<OrderItemModel>();
        }
    }
}
