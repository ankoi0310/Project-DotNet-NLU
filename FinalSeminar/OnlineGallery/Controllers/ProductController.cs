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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Product/List
        public async Task<IActionResult> List()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Product/CreateOrUpdate
        // GET: Product/CreateOrUpdate/5
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Product());
            }
            else
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }

        // POST: Product/CreateOrUpdate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    if (product.FileImage != null)
                    {
                        product.Image = Tools.SaveImage(_webHostEnvironment, product.FileImage);
                    }
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        if (product.FileImage != null)
                        {
                            var oldProduct = _context.Products.Find(id);
                            Tools.RemoveImage(_webHostEnvironment, oldProduct.Image);
                            oldProduct.Image = Tools.SaveImage(_webHostEnvironment, product.FileImage);
                            _context.Update(oldProduct);
                        }
                        else
                        {
                            _context.Update(product);
                        }
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
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Products.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "CreateOrUpdate", product) });
        }

        // GET: Product/AddImage
        // GET: Product/AddImage/5
        [NoDirectAccess]
        public async Task<IActionResult> AddImage(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Sold/5
        [HttpPost, ActionName("Sold")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoldConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            product.Status = false;
            _context.Update(product);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Products.ToList()) });
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
