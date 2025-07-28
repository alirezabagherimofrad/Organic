using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Address
{
    public class AddressModel
    {
        private AddressModel() { }

        public Guid Id { get; private set; }

        public string City { get; private set; }

        public string FullAddress { get; private set; }

        public string PostalCode { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdateAt { get; private set; }

        public AddressModel(string city, string fullAddress, string postalCode)
        {
            Id = Guid.NewGuid();

            City = city;

            FullAddress = fullAddress;

            PostalCode = postalCode;

            CreatedAt = DateTime.Now;
        }
    }
}
