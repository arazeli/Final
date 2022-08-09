using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.ViewModels;

namespace T_Shirt_Store.WebUI.Controllers
{
    public class BlogsController : Controller
    {
        readonly T_Shirt_StoreDbContext db;
        public BlogsController(T_Shirt_StoreDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.BlogPosts
            .Where(bp=>bp.DeletedByID==null)
                .ToList();
            return View(data);
        }

        public IActionResult Details(int id )
        {   var viewModel = new SinglePostViewModel();
            var data = db.BlogPosts

                .Include(bp=>bp.TagCloud)
                .ThenInclude(bp => bp.PostTag)
                .FirstOrDefault(bp => bp.DeletedByID == null && bp.Id == id);
            if(data==null)
            {
                return NotFound();
            }
                
            return View(data);
        }
    }
}
