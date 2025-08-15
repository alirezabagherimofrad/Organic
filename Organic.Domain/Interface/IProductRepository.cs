using Organic.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Interface
{
    public interface IProductRepository
    {
        Task<ProductModel> GetByIdAsync(int id);
    }
}
