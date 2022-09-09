using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly T_Shirt_StoreDbContext db;
        readonly IWebHostEnvironment env;

        public BlogPostsController(T_Shirt_StoreDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        // GET: Admin/BlogPosts
        public async Task<IActionResult> Index()
        {
            var techShedDbContext = db.BlogPosts.Include(b => b.Category);
            return View(await techShedDbContext
                .Where(b => b.DeletedByID == null)
                .ToListAsync());
        }

        // GET: Admin/BlogPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedByID == null);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost blogPost, IFormFile file, int[] tagIds)
        {
            if (file == null)
            {
                ModelState.AddModelError("ImagePath", "Fayl Secilmeyib");
            }
            if (ModelState.IsValid)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                string name = $"blog-{Guid.NewGuid()}{fileExtension}";

                string physicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", name);

                using (var fs = new FileStream(physicalPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fs);
                }

                blogPost.ImagePath = name;

                await db.AddAsync(blogPost);
                int affected = await db.SaveChangesAsync();


                if (affected > 0 && tagIds != null && tagIds.Length > 0)
                {
                    foreach (var item in tagIds)
                    {
                        await db.BlogPostTagCloud.AddAsync(new BlogPostTag
                        {
                            BlogPostId = blogPost.Id,
                            PostTagId = item
                        });
                    }
                    await db.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));




            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blogPost.CategoryId);
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");

            return View(blogPost);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .Include(bp => bp.TagCloud)
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedByID == null);
            if (blogPost == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blogPost.CategoryId);
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");

            return View(blogPost);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, BlogPost blogPost, IFormFile file, int[] tagIds)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (file == null && string.IsNullOrWhiteSpace(blogPost.ImagePath))
            {
                ModelState.AddModelError("ImagePath", "Fayl Secilmeyib");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    var currentEntity = db.BlogPosts
                        .FirstOrDefault(bp => bp.Id == id);



                    if (currentEntity == null)
                    {
                        return NotFound();
                    }

                    string OldFileName = currentEntity.ImagePath;

                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);

                        string name = $"blog-{Guid.NewGuid()}{fileExtension}";

                        string physicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", name);

                        using (var fs = new FileStream(physicalPath, FileMode.Create, FileAccess.Write))
                        {
                            file.CopyTo(fs);
                        }

                        currentEntity.ImagePath = name;

                        string physicalPathOld = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", OldFileName);

                        if (System.IO.File.Exists(physicalPathOld))
                        {
                            System.IO.File.Delete(physicalPathOld);
                        }
                    }

                    currentEntity.CategoryId = blogPost.CategoryId;
                    currentEntity.Title = blogPost.Title;
                    currentEntity.Body = blogPost.Body;

                    if (tagIds != null && tagIds.Length > 0)
                    {
                        foreach (var item in tagIds)
                        {
                            if (db.BlogPostTagCloud.Any(bptc => bptc.PostTagId == item && bptc.BlogPostId == blogPost.Id))
                            {
                                continue;
                            }
                            await db.BlogPostTagCloud.AddAsync(new BlogPostTag
                            {
                                BlogPostId = blogPost.Id,
                                PostTagId = item
                            });
                        }
                        await db.SaveChangesAsync();
                    }

                    //db.Entry(blogPost).Property(p => p.CreatedById).IsModified = false;
                    //db.Entry(blogPost).Property(p => p.CreatedDate).IsModified = false;
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blogPost.CategoryId);
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");

            return View(blogPost);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var blogPost = await db.BlogPosts.FirstOrDefaultAsync(bp => bp.Id == id && bp.DeletedByID == null);

            if (blogPost == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Qeyd Mövcud Deyil"
                });
            }

            blogPost.DeletedByID = 1;
            blogPost.DeletedDate = DateTime.UtcNow.AddHours(4);


            db.BlogPosts.Remove(blogPost);
            await db.SaveChangesAsync();


            return Json(new
            {
                error = false,
                message = "Qeyd Silindi"
            });
        }

        private bool BlogPostExists(int id)
        {
            return db.BlogPosts.Any(e => e.Id == id);
        }
    }
}
