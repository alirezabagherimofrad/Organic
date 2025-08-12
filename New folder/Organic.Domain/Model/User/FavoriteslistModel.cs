using Organic.Domain.Model.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.User
{
    public class FavoriteslistModel
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        // با توجه به figma
        public string ProductName { get; private set; } = string.Empty;
        public checkproduct Checkproduct { get; private set; }

        public DateTime AddAt { get; private set; } = DateTime.Now;

        public FavoriteslistModel(Guid userId, Guid productId, string productName, checkproduct checkproduct)
        {
            Id=Guid.NewGuid();
            UserId=userId;
            ProductId=productId;
            ProductName = productName;
            Checkproduct =  checkproduct;
        }

        public enum checkproduct
        {
            Available,
            Not_available
        }

        private FavoriteslistModel() { }

        //public void ADDfavoritList(Guid userId, Guid productId, string productname, )
        //{

        //}
    }

}
