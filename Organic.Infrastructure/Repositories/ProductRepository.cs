using Organic.Domain.Interface;
using Organic.Domain.Model.Product;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories
{
    // در لایه Infrastructure
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseContext _db;

        public ProductRepository(DataBaseContext db)
        {
            _db = db;
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            return await _db.ProductModel.FindAsync(id);
        }

        Task<ProductModel> IProductRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
