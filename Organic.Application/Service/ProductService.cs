using Organic.Application.Interface;
using Organic.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Service
{
    public class ProductService
    {
        private readonly ICacheService _cache;
        private readonly IProductRepository _repo;

        public ProductService(ICacheService cache, IProductRepository repo)
        {
            _cache = cache;
            _repo = repo;
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var cacheKey = $"product:{id}";

            // بررسی کش
            var cached = await _cache.GetAsync<ProductModel>(cacheKey);
            if (cached != null) return cached;

            // گرفتن از دیتابیس
            var product = await _repo.GetByIdAsync(id);

            // ذخیره در کش
            await _cache.SetAsync(cacheKey, product, TimeSpan.FromMinutes(5));

            return product;
        }
    }

}
