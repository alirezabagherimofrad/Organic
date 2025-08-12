using Organic.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Discount
{
    public class DiscountModel
    {
        private DiscountModel() { }

        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public int DiscountPercent { get; private set; }

        public int DurationDays { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public ProductModel Product { get; private set; } 

        public DiscountModel(Guid productId, int discountPercent, int durationDays)
        {
            Id = Guid.NewGuid();

            ProductId = productId;

            DiscountPercent = discountPercent;

            DurationDays = durationDays;

            CreatedAt = DateTime.Now;
        }
    }
}
