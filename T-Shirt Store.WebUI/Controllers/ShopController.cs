using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.ViewModels;

namespace T_Shirt_Store.WebUI.Controllers
{
    public class ShopController : Controller
    {
        readonly T_Shirt_StoreDbContext db;
        public ShopController(T_Shirt_StoreDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            

            var model = new ShopIndexViewModel();
            model.Brands = db.Brands.ToList();
            model.Productcolors = db.Colors.ToList();
            model.Productsizes = db.Sizes.ToList();
            model.Categories = db.Categories
                .Include(c=>c.Children)
                .ToList();

            return View(model);
        }
    }
}
