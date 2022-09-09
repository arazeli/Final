using Microsoft.AspNetCore.Authorization;
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
            ShopIndexViewModel vm = new ShopIndexViewModel();

            vm.Brands = db.Brands
                .Where(b => b.DeletedByID == null)
                .ToList();

            vm.Colors = db.Colors
                .Where(c => c.DeletedByID == null)
                .ToList();

            vm.Categories = db.Categories
                .Include(cg=>cg.Children)
                .ThenInclude(cg => cg.Children)
                .Where(cg => cg.DeletedByID == null && cg.ParentId == null)
                .ToList();

            vm.Products = db.Products
                .Include(p=>p.Images.Where(i=>i.IsMain==true))
                .Include(p=>p.Brand)
                .Where(p=>p.DeletedByID==null)
                .ToList();


            return View(vm);
           
           
        }



        public IActionResult Details(int id)
        {
           
            var product = db.Products
                .Include(p =>p.Images)
                .FirstOrDefault(p => p.Id == id && p.DeletedByID == null);
            if (product==null)
            
            {
                return NotFound();
            }
            return View(product);
        }
        //public IActionResult Filter(int categoryId)
        //{
        //    var categories = db.Products.Where(p => p.CategoryId == categoryId).ToList();

        //}

    }
}
