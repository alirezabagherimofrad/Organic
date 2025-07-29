using Organic.Domain.Interface.ProductImageInterface;
using Organic.Domain.Model.Product;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.ProductImageRepository
{
    public class CrudProductImageRepository : GenricCommandRepository<ProductImageModel>, ICrudProductImageRepository
    {
        public CrudProductImageRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
