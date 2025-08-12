using Microsoft.EntityFrameworkCore;
using Organic.Domain.Interface;
using Organic.Domain.Model.Order;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.ProductCategoryRepository
{

    public class BasketRepository : IBasketRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public BasketRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<Basket?> basketwhitUserId(Guid userId)
        {
            return await _dataBaseContext.baskets
                                 .Include(b => b.basketItemModels)
                                 .FirstOrDefaultAsync(b => b.UserId == userId);
        }
    }
}
