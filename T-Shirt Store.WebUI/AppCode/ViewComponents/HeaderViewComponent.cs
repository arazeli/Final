using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Controllers;
using T_Shirt_Store.WebUI.Models.DataContexts;

namespace T_Shirt_Store.WebUI.AppCode.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        readonly T_Shirt_StoreDbContext db;
        public HeaderViewComponent(T_Shirt_StoreDbContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            var data = db.Categories
                .Select(c => new {
                    Id = c.Id,
                    Name = c.ParentId == null ? c.Name : $"- {c.Name}"
                })
                .ToList();
            ViewBag.Categories = new SelectList(data, "Id", "Name");
            return View();
        }
    }
}
