using Organic.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Interface
{
    public interface  IBasketRepository
    {
        Task<Basket?> basketwhitUserId(Guid userId);
    }
}
