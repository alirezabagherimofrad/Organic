using Organic.Domain.Model.User;
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
        public Guid UserId { get; private set; }
        public bool CurrentAddress {  get; private set; }
        public UserModel User { get; private set; }

        public AddressModel(string city, string fullAddress, string postalCode, Guid userId, bool currentAddress)
        {
            Id = Guid.NewGuid();
            City = city;
            FullAddress = fullAddress;
            PostalCode = postalCode;
            UserId=userId;
            CurrentAddress=currentAddress;
        }
        public void AddAddress(Guid userId,string city, string fullAddress, string postalCode, bool currentAddress)
        {
            UserId = userId;
            City = city;
            FullAddress = fullAddress;
            PostalCode = postalCode;
            CreatedAt = DateTime.Now;
            CurrentAddress=currentAddress;
        }
        public void UpdateAddress(string city, string fullAddress, string postalCode)
        {
            City = city;
            FullAddress = fullAddress;
            PostalCode = postalCode;
            UpdateAt = DateTime.Now;
        }
    }
}
