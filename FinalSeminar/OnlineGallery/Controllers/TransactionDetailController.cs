using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    public class TransactionDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await _context.Products.ToListAsync();
            await _context.Auctions.ToListAsync();
            return View(await _context.TransactionDetails.ToListAsync());
        }
    }
}
