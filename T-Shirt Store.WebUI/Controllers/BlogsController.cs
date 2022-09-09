using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = db.BlogPosts
                .Where(bp => bp.DeletedByID == null)
                .ToList();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var post = db.BlogPosts
                .Include(bp => bp.TagCloud)
                .ThenInclude(bp => bp.PostTag)
                .FirstOrDefault(bp => bp.DeletedByID == null && bp.Id == id);


            if (post == null)
            {
                return NotFound();
            }
            var viewModel = new SinglePostViewModel();
            viewModel.Post = post;


            var tagIdsQuery = post.TagCloud.Select(tc => tc.PostTagId);

            viewModel.RelatedPosts = db.BlogPosts
            .Include(bp => bp.TagCloud)
            .Where(bp => bp.Id != id && bp.DeletedByID == null
            && bp.TagCloud.Any(tc => tagIdsQuery.Any(qId => qId == tc.PostTagId)))
            .OrderByDescending(bp => bp.Id)
            .Take(6)
            .ToList();



            //viewModel.RelatedPosts = (from bp in db.BlogPosts
            //                          join tc in db.BlogPostTagCloud on bp.Id equals tc.BlogPostId
            //                          where bp.Id != id  && bp.DeletedById == null && tagIdsQuery.Any(q => q == tc.PostTagId)
            //                          select bp)
            //                          .Distinct()
            //                          .ToList();



            return View(viewModel);
        }
    }
}
