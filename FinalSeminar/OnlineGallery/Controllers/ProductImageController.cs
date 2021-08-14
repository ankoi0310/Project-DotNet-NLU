using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Data;
using OnlineGallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            await _context.Products.ToListAsync();
            return View(await _context.ProductImages.ToListAsync());
        }

        // GET: Product/CreateOrUpdate
        // GET: Product/CreateOrUpdate/5
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrUpdate(int id = 0)
        {
            await _context.Products.ToListAsync();
            if (id == 0)
            {
                return base.View(new ProductImage());
            }
            else
            {
                var productImage = await _context.ProductImages.FindAsync(id);
                if (productImage == null)
                {
                    return NotFound();
                }
                return View(productImage);
            }
        }

        // POST: Product/CreateOrUpdate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(int id, ProductImage productImage)
        {
            if (id == 0 && productImage.FileImage == null)
            {
                ModelState.AddModelError("Image", "- Please choose at least 1 image.");
            }
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    foreach (var image in productImage.FileImage)
                    {
                        ProductImage item = new() { ProductId = productImage.ProductId, Image = Tools.SaveImage(_webHostEnvironment, image) };
                        _context.Add(item);
                        await _context.SaveChangesAsync();
                    }
                    var product = await _context.Products.FindAsync(productImage.ProductId);
                    product.Status = true;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        if (productImage.FileImage != null)
                        {
                            Tools.RemoveImage(_webHostEnvironment, productImage.Image);
                            productImage.Image = Tools.SaveImage(_webHostEnvironment, productImage.FileImage[0]);
                        }
                        _context.Update(productImage);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductImageExists(productImage.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.ProductImages.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "CreateOrUpdate", productImage) });
        }

        // POST: ProductImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            var productId = productImage.ProductId;
            Tools.RemoveImage(_webHostEnvironment, productImage.Image);
            _context.Remove(productImage);
            await _context.SaveChangesAsync();
            if (!Tools.CheckGalleryProduct(_context, productId.Value))
            {
                var product = await _context.Products.FindAsync(productId);
                product.Status = false;
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.ProductImages.ToList()) });
        }

        private bool ProductImageExists(int id)
        {
            return _context.ProductImages.Any(e => e.Id == id);
        }
    }
}
