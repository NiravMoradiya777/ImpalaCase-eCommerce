using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.Modules
{
    public class OrdersModule
    {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public int CaseId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Constructor
        public OrdersModule(int id, int bundleId, int caseId, decimal quantity, decimal unitPrice)
        {
            Id = id;
            BundleId = bundleId;
            CaseId = caseId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }

    public class OrdersWithTitleModule
    {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public int CaseId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        // Constructor
        public OrdersWithTitleModule(int id, int bundleId, int caseId, decimal quantity, decimal unitPrice, string title, string image)
        {
            Id = id;
            BundleId = bundleId;
            CaseId = caseId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Title = title;
            Image = image;
        }
    }

}