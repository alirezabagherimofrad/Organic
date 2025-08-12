using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Order
{
    public class Basket 
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public List<BasketItemModel> basketItemModels { get; private set; } = new();
        public Basket(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
        }

        public Basket() { }

        public void Clear()
        {
            basketItemModels.Clear();
        }
        public void AddItem(BasketItemModel item)
        {
            basketItemModels.Add(item);
        }

    }
}
