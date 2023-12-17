using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.Modules
{
    public class PhoneCaseModule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string About { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; }
        public string Color { get; set; }
        public string CompatiblePhoneModels { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        // Constructor
        public PhoneCaseModule(int id, string title, string image, string shortDescription,
            string longDescription, string about, decimal weight, string dimensions,
            string color, string compatiblePhoneModels, string material, decimal price, bool isActive = true)
        {
            Id = id;
            Title = title;
            Image = image;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            About = about;
            Weight = weight;
            Dimensions = dimensions;
            Color = color;
            CompatiblePhoneModels = compatiblePhoneModels;
            Material = material;
            Price = price;
            IsActive = isActive;
        }
    }

}