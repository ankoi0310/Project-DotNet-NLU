using OnlineGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OnlineGallery.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace OnlineGallery.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Product()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Home/ProductDetail/1
        public IActionResult ProductDetail(int id)
        {
            Product product = _context.Products.Find(id);
            ViewBag.ImageList = _context.ProductImages.Where(e => e.ProductId == id).ToList();
            return View(product);
        }

        public IActionResult Auction()
        {
            return View();
        }

        // GET: Home/AuctionDetail/1
        public IActionResult AuctionDetail(int id)
        {
            Auction auction = _context.Auctions.Find(id);
            return View(auction);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }

        public bool AddOrRemoveFavorites(string userId, int productId)
        {

            return false;
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
