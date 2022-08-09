using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.Models.ViewModels
{
    public class ShopIndexViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<ProductSize> Productsizes { get; set; }
        public List<ProductColor> Productcolors { get; set; }
        public List<Category> Categories { get; set; }

    }
}
