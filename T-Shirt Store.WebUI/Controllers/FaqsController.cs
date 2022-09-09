using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.DataContexts;

namespace T_Shirt_Store.WebUI.Controllers
{
    [AllowAnonymous]
    public class FaqsController : Controller
    {
        readonly T_Shirt_StoreDbContext db;
        public FaqsController(T_Shirt_StoreDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var faqs = db.Faqs.ToList();
            return View(faqs);
        }
    }
}
