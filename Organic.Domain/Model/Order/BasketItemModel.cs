using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Order
{
    public class BasketItemModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int UnitPrice { get; private set; }

        public int TotalPrice => Quantity * UnitPrice;

        public BasketItemModel(Guid productId, int quantity, int unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        private BasketItemModel() { }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
