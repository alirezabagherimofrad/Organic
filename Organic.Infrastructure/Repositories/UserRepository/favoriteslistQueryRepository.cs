using Microsoft.EntityFrameworkCore;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model.Product;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.UserRepository
{
    public class favoriteslistQueryRepository : IfavoriteslistQueryRepository
    {
        private readonly DataBaseContext _Context;
        public favoriteslistQueryRepository(DataBaseContext context)
        {
            _Context=context;
        }

        public async Task<FavoriteslistModel?> favoriteslist(Guid userId, Guid productId)
        {
           return await _Context.favoriteslistModels.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
        }
    }
}
