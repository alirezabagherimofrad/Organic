using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Product
{
    public class FavoriteslistModel
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTime AddAt { get; private set; } = DateTime.Now;

        public FavoriteslistModel(Guid userId, Guid productId)
        {
            Id=Guid.NewGuid();
            UserId=userId;
            ProductId=productId;
        }

        private FavoriteslistModel() { }
    }
}
