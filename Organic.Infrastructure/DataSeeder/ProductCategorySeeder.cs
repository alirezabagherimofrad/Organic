using Microsoft.EntityFrameworkCore;
using Organic.Domain.Model.Product;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.DataSeeder
{
    public class ProductCategorySeeder
    {
        public static async Task CategorySeeder(DataBaseContext Context)
        {

            var categories = new List<ProductCategoryModel>
            {
                  new ProductCategoryModel("گوشت و مرغ", Guid.Parse("673d2e32-3851-45bc-bc5d-7eca3d80d4eb")),

                  new ProductCategoryModel("میوه و سبزیجات", Guid.Parse("c14ffe28-b26a-440f-89d5-f12467c58e37")),

                  new ProductCategoryModel("لبنیات", Guid.Parse("cd84704c-2045-4825-83c7-cd7c4604080a")),

                  new ProductCategoryModel("آرایشی و بهداشتی", Guid.Parse("e0ec6b39-8a2f-4b79-ae0f-19b4590865f0")),

                  new ProductCategoryModel("عرقیجات", Guid.Parse("79248cd9-cadb-4143-8307-cf1479ebdfc6")),

                  new ProductCategoryModel("نان و تخم مرغ", Guid.Parse("3ccb8cbc-8d58-4f52-8986-bdeb66718028")),
            };

            var existsCategory = await Context.Set<ProductCategoryModel>().Select(c => c.Id).ToListAsync(); ;

            var addCategories = categories.Where(c => !existsCategory.Contains(c.Id)).ToList();

            if (addCategories.Any())
            {
                await Context.ProductCategoryModel.AddRangeAsync(addCategories);

                await Context.SaveChangesAsync();
            }
        }
    }
}
