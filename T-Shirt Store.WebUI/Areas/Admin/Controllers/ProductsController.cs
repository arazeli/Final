using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.AppCode.infrastructure;
using T_Shirt_Store.WebUI.AppCode.Modules.ProductModule;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly T_Shirt_StoreDbContext _context;
        private readonly IMediator mediator;

        public ProductsController(T_Shirt_StoreDbContext context, IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var T_Shirt_StoreDbContext = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Images.Where(i => i.IsMain == true));

            var images = await _context.ProductImages.Where(p=>p.DeletedByID == null).ToListAsync();

            ViewBag.Images = images;
            return View(await T_Shirt_StoreDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");

            ViewData["Colors"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["Sizes"] = new SelectList(_context.Sizes, "Id", "Name");

            ViewBag.Specifications = _context.Specifications.Where(s => s.DeletedByID==null)
                .ToList();
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ProductCreateCommand model)
        {
            var response = await mediator.Send(model);

            if (response?.ValidationResult!=null && !response.ValidationResult.IsValid)
            {
                return Json(response.ValidationResult);
            }
            return Json(new CommandJsonResponse(false, $"Ugurlu emeliyyat.Yeni mehsulun kodu:{response.Product.Id}"));
 
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p=>p.Images)
                .Include(p => p.Specifications)

                .Include(p => p.Pricings)
                .ThenInclude(p => p.Color)

                .Include(p => p.Pricings)
                .ThenInclude(p => p.ProductSize)
                .FirstOrDefaultAsync(p=>p.Id==id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["Colors"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["Sizes"] = new SelectList(_context.Sizes, "Id", "Name");

            ViewBag.Specifications = _context.Specifications.Where(s => s.DeletedByID == null)
                .ToList();

            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditCommand model)
        {

            var response = await mediator.Send(model);

            if (response?.ValidationResult != null && !response.ValidationResult.IsValid)
            {
                return Json(response.ValidationResult);
            }
            return Json(new CommandJsonResponse(false, $"Ugurlu emeliyyat.Yeni mehsulun kodu:{response.Product.Id}"));

        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
