using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_Shirt_Store.WebUI.AppCode.Modules.ProductModule
{
    public class ProductPricing
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public double Price { get; set; }

    }
}
