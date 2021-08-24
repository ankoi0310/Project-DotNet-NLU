using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuctionRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuctionRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuctionRecord
        // GET: AuctionRecord/Index
        public async Task<IActionResult> Index()
        {
            await _context.Products.ToListAsync();
            await _context.Auctions.ToListAsync();
            await _context.Users.ToListAsync();
            return View(await _context.AuctionRecords.ToListAsync());
        }
    }
}
