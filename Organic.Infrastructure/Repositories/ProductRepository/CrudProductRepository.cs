using Organic.Domain.Interface.ProductInterface;
using Organic.Domain.Model.Product;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.ProductRepository
{
    public class CrudProductRepository : GenricCommandRepository<ProductModel>, ICrudProductRepository
    {
        public CrudProductRepository(DataBaseContext context) : base(context)
        {
        } 
    }
}
