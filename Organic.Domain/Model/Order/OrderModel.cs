using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Organic.Domain.Model.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Order
{
    public class OrderModel
    {
        private OrderModel() { }

        public Guid Id { get; private set; }

        public int OrderNumber { get; private set; }

        public Guid AddressId { get; private set; }

        public AddressModel Address { get; private set; }

        public DateTime OrderDate { get; private set; }

        public int TotalPrice { get; private set; }

        public SelectOrderStatus OrderStatus { get; private set; }

        // ✅ درست: هر سفارش دارای لیستی از آیتم‌هاست
        public ICollection<OrderItemModel> OrderItems { get; private set; } = new List<OrderItemModel>();

        public int TrackingNumber { get; private set; }

        public enum SelectOrderStatus
        {
            [Display(Name = "Packed")] Packed,

            [Display(Name = "Sent")] Sent,

            [Display(Name = "NotSent")] NotSent,

            [Display(Name = "Completion")] Completion
        }

        public OrderModel(Guid addressId, int totalPrice, int orderNumber)
        {
            Id = Guid.NewGuid();
            AddressId = addressId;
            OrderNumber = orderNumber;
            TotalPrice = totalPrice;
            OrderDate = DateTime.Now;
        }
    }
}
