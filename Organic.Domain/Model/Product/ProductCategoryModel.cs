using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Product
{
    public class ProductCategoryModel
    {
        private ProductCategoryModel() { }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<ProductModel> Products { get; private set; }

        public ProductCategoryModel(string name, Guid id)
        {
            Id = id;
            Name = name;
            Products = new List<ProductModel>();
        }
    }
}
