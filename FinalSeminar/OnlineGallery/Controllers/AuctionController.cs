using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Data;
using OnlineGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuctionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuctionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Auction/List
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auctions.ToListAsync());
        }

        // GET: Auction/CreateOrUpdate
        // GET: Auction/CreateOrUpdate/5
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Auction());
            }
            else
            {
                await _context.Products.ToListAsync();
                var auction = await _context.Auctions.FindAsync(id);
                if (auction == null)
                {
                    return NotFound();
                }
                return View(auction);
            }
        }

        // GET: Auction/CreateAuction/5
        [NoDirectAccess]
        public async Task<IActionResult> CreateAuction(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return View(new Auction() { ProductId = id, Product = product });
        }

        // POST: Auction/CreateOrUpdate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(int id, Auction auction)
        {
            if (auction.StartDay.Value.CompareTo(DateTime.Now) < 0)
            {
                ModelState.AddModelError("DateError", "- The starting day cannot be earlier than today.");
            }
            else if (auction.StartDay.Value.CompareTo(auction.ClosingDay.Value) >= 0)
            {
                ModelState.AddModelError("DateError", "- The starting day cannot be greater or the same day as the closing day.");
            }
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(auction);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(auction);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AuctionExists(auction.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Auctions.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "CreateOrUpdate", auction) });
        }

        // POST: Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            _context.Remove(auction);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Auctions.ToList()) });
        }

        private bool AuctionExists(int id)
        {
            return _context.Auctions.Any(e => e.Id == id);
        }
    }
}
