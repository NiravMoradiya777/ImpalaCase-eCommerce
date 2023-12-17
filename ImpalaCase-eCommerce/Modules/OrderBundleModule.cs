using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.Modules
{
    public class OrderBundleModule
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public decimal Discount { get; set; }
        public decimal ShippingPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }

        // Constructor
        public OrderBundleModule(int id, int loginId, string fullName, string contactNumber,
            string address, string city, string zip, decimal discount, decimal shippingPrice,
            DateTime orderDate, string status, decimal total)
        {
            Id = id;
            LoginId = loginId;
            FullName = fullName;
            ContactNumber = contactNumber;
            Address = address;
            City = city;
            ZIP = zip;
            Discount = discount;
            ShippingPrice = shippingPrice;
            OrderDate = orderDate;
            Status = status;
            Total = total;
        }
    }

}