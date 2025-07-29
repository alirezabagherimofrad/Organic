using Organic.Domain.Interface.ProductCategory;
using Organic.Domain.Model.Product;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.ProductCategoryRepository
{
    public class GetProductCategoryRepository : GenricQueryRepository<ProductCategoryModel>, IGetProductCategoryRepository
    {
        public GetProductCategoryRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }
    }
}
