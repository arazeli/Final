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
            var t_Shirt_StoreDbContext =await db.BlogPosts.Include(b => b.Category)
            .Where(b=>b.DeletedByID==null)
            .ToListAsync();

            return View(t_Shirt_StoreDbContext);
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
                .Where(b => b.DeletedByID == null)
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
            return View();
        }

        // POST: Admin/BlogPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BlogPost blogPost,IFormFile file)
        {
            if (file==null)
            {
                ModelState.AddModelError("ImagePath","Fayl secilmeyib");
            }

            if (ModelState.IsValid)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                string name = $"blog-{Guid.NewGuid()}{fileExtension}";
                string physicalPath = Path.Combine(env.ContentRootPath,"wwwroot","uploads","images",name);

                using (var fs= new FileStream(physicalPath,FileMode.Create,FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                blogPost.ImagePath = name;

                db.Add(blogPost);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blogPost.CategoryId);
            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedByID == null);
            if (blogPost == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blogPost.CategoryId);
            return View(blogPost);
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, BlogPost blogPost,IFormFile file)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (file== null && string.IsNullOrWhiteSpace(blogPost.ImagePath))
            {
                ModelState.AddModelError("ImagePath", "Fayl secilmeyib");
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

                    string oldFileName = currentEntity.ImagePath;

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


                        string physicalPathOld = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", oldFileName);
                        if (System.IO.File.Exists(physicalPathOld))
                        {
                            System.IO.File.Delete(physicalPathOld);
                        }

                    }


                    currentEntity.CategoryId = blogPost.CategoryId;
                    currentEntity.Title = blogPost.Title;
                    currentEntity.Body = blogPost.Body;
                    //db.Entry(currentEntity).Property(p=>p.CreateById).IsModified=false;
                    //db.Entry(currentEntity).Property(p => p.CreateDate).IsModified = false;
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
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", blogPost.CategoryId);
            return View(blogPost);
        }

     
        [HttpPost]
       
        public async Task<IActionResult> Delete(int id)
        {
            var blogPost = await db.BlogPosts.FirstOrDefaultAsync(bp=>bp.Id==id && bp.DeletedByID == null);
            if (blogPost == null)
            {
                return Json(new {
                error=true,
                message="Qeyd movcud deyil"
                });
            }

            blogPost.DeletedByID = 1;
            blogPost.DeletedDate = DateTime.UtcNow.AddHours(4);
            
            await db.SaveChangesAsync();

            return Json(new
            {
                error = false,
                message = "Qeyd silindi"
            });

        }

        private bool BlogPostExists(int id)
        {
            return db.BlogPosts.Any(e => e.Id == id);
        }
    }
}
