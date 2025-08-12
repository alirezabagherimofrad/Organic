using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Product
{
    public class ProductImageModel
    {
        private ProductImageModel() { }

        public Guid Id { get; private set; }

        public string FilePath { get; private set; }

        public string ImageUrl { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public Guid ProductId { get; private set; }

        public ProductModel Product { get; private set; }

        public ProductImageModel(string filePath, string imageUrl, Guid productId)
        {
            Id = Guid.NewGuid();

            FilePath = filePath;

            ImageUrl = imageUrl;

            ProductId = productId;

            CreatedAt = DateTime.Now;
        }

    }
}
