using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Product
{
    public class ProductModel
    {
        private ProductModel() { }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Price { get; private set; }

        public string? Description { get; private set; }

        public int? Stock { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public Guid CatrgoryId { get; private set; }

        public decimal? DiscountPercent { get; private set; } // میزان درصد تخفیف 

        public int? DiscountDuration { get; private set; } // میزان مدت زمانی که برای اون تخفیف در نظر گرفته شده 

        public ProductCategoryModel ProductCategory { get; private set; }

        public ICollection<ProductImageModel> ProductImages { get; private set; }

        public ProductModel(string name, int price, int stock, string? description, Guid catrgoryId)
        {
            Id = Guid.NewGuid();

            Name = name;

            Price = price;

            Stock = stock;

            CreatedAt = DateTime.Now;

            Description = description;

            CatrgoryId = catrgoryId;

            ProductImages = new List<ProductImageModel>();
        }

        public void Update(string name, int price, string? description, int? stock)
        {
            Name = name;

            Price = price;

            Stock = stock;

            UpdatedAt = DateTime.Now;

            Description = description;
        }

        public void UpdateTime(DateTime dateTime)
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetDiscount(decimal? discountPercent, int? discountDuration)
        {
            DiscountPercent = discountPercent;

            DiscountDuration = discountDuration;
        }
    }
}
