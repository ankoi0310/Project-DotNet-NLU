using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await _context.Users.ToListAsync();
            return View(await _context.Transactions.ToListAsync());
        }

        public async Task<IActionResult> Detail(int id)
        {
            await _context.Products.ToListAsync();
            await _context.Auctions.ToListAsync();
            await _context.Transactions.ToListAsync();
            var detail = await _context.TransactionDetails.Where(e => e.TransactionId.Equals(id)).ToListAsync();
            return View(detail);
        }
    }
}
