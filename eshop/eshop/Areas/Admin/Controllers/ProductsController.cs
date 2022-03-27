using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eshop.DAL;
using eshop.Models;
using Microsoft.AspNetCore.Http;
using eshop.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace eshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.SubCategory).Include(p=>p.ProductImages);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SubCategoryId,Price,OffPercentage,StarCount,IsNew,ImageFiles")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFiles != null && product.ImageFiles.Length > 0)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    foreach (IFormFile item in product.ImageFiles)
                    {
                        if (!item.IsImage())
                        {
                            ModelState.AddModelError("ImageFiles", item.FileName + "is not an image.");
                            _context.Products.Remove(_context.Products.Find(product.Id));
                            await _context.SaveChangesAsync();
                            return View(product);
                        }

                        if (!item.IsValidSize(500))
                        {
                            ModelState.AddModelError("ImageFiles", item.FileName + "is too big.");
                            _context.Products.Remove(_context.Products.Find(product.Id));
                            await _context.SaveChangesAsync();
                            return View(product);
                        }

                        ProductImage pi = new ProductImage();
                        pi.Image = await item.Upload(_env.WebRootPath, @"uploads\products");
                        pi.ProductId = product.Id;

                        await _context.ProductImages.AddAsync(pi);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                ModelState.AddModelError("ImageFiles", "At least one image is required");
                ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
                return View(product);
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["ProductImages"] = await _context.ProductImages.Where(x => x.ProductId == id).ToListAsync();

            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id== id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,SubCategoryId,Price,OffPercentage,StarCount,IsNew,Id,ImageFiles")] Product product)
        {
            ViewData["ProductImages"] = await _context.ProductImages.Where(x=>x.ProductId == product.Id).ToListAsync();
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (product.ImageFiles != null && product.ImageFiles.Length > 0)
                {
                    if (product.ImageFiles.ImagesAreValid())
                    {

                    List<ProductImage> images = await _context.ProductImages.Where(x => x.ProductId == product.Id).ToListAsync();
                    foreach (ProductImage item in images)
                    {
                        string filePath = Path.Combine(_env.WebRootPath, @"uploads\products", item.Image);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        _context.ProductImages.Remove(item);
                    }

                    foreach (IFormFile item in product.ImageFiles)
                    {
                        ProductImage pi = new ProductImage();
                        pi.Image = await item.Upload(_env.WebRootPath, @"uploads\products");
                        pi.ProductId = product.Id;
                        await _context.ProductImages.AddAsync(pi);
                    }
                    await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
                        ModelState.AddModelError("ImageFiles", "Images are not valid.");
                        return View(product);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

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
