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
using Microsoft.AspNetCore.Identity;
using OnlineGallery.Areas.Identity.Data;
using System.Timers;
using Newtonsoft.Json;

namespace OnlineGallery.Controllers
{
    public class HomeController : Controller
    {
        private const int pageSize = 3;
        private readonly ApplicationDbContext _context;
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options, ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _options = options;
            _logger = logger;
            _userManager = userManager;
            SetTimer();
        }

        public async Task<IActionResult> Index()
        {
            await _context.AuctionRecords.ToListAsync();
            await _context.Auctions.ToListAsync();
            await _context.Products.ToListAsync();
            return View();
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var isInCart = Tools.IsInCart(_context, user.Id, id);
                if (isInCart)
                {
                    return Json(new { add = false, id = id, status = "Already in cart !" });
                }
                var product = await _context.Products.FindAsync(id);
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(new List<Product>() { product }));
                _context.Add(new Cart() { ProductId = id, UserId = user.Id });
                await _context.SaveChangesAsync();
                return Json(new { add = true, id = id, status = "Add to cart successfully !" });
            }
            return Json(new { add = false, id = 0, status = "Please login to continue !" });
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var productInCart = await _context.Carts.FindAsync(user.Id, id);
            _context.Remove(productInCart);
            await _context.SaveChangesAsync();
            return Json(new { remove = true, status = "Remove successfully !" });
        }

        //public async Task<IActionResult> Checkout()
        //{
        //    return Task.CompletedTask;
        //}

        [HttpGet]
        public async Task<IActionResult> Product(int page = 1)
        {
            await _context.Auctions.ToListAsync();
            var query = _context.Products.Where(e => e.Status);
            decimal totalSize = await query.CountAsync();
            if (page < 1 || page > Math.Ceiling(totalSize / pageSize))
            {
                return Redirect("~/Identity/Account/AccessDenied");
            }
            ViewBag.CurrentPage = page;
            var products = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            return View(products);
        }

        // GET: Home/ProductDetail/1
        public async Task<IActionResult> ProductDetail(int id)
        {
            await _context.Auctions.ToListAsync();
            Product product = await _context.Products.FindAsync(id);
            return View(product);
        }

        public async Task<IActionResult> Auction(int page = 1)
        {
            await _context.Products.ToListAsync();
            await _context.AuctionRecords.ToListAsync();
            var query = _context.Auctions.Where(e => e.Status);
            decimal totalSize = await query.CountAsync();
            if (page < 1 || page > Math.Ceiling(totalSize / pageSize))
            {
                return Redirect("~/Identity/Account/AccessDenied");
            }
            ViewBag.CurrentPage = page;
            var auctions = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            return View(auctions);
        }

        // GET: Home/AuctionDetail/1
        public async Task<IActionResult> AuctionDetail(int id)
        {
            await _context.Products.ToListAsync();
            await _context.AuctionRecords.ToListAsync();
            Auction auction = await _context.Auctions.FindAsync(id);
            return View(auction);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Bidding(int auctionId, int bidPrice)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var role = await _userManager.GetRolesAsync(user);
            var auction = await _context.Auctions.FindAsync(auctionId);
            var minBid = auction.StartingPrice + auction.StepPrice;
            if (user != null)
            {
                if (bidPrice >= minBid)
                {
                    // Create record
                    AuctionRecord auctionRecord = new() { Auction = auction, AuctionId = auctionId, UserId = user.Id, BidPrice = bidPrice, Day = DateTime.Now };
                    _context.Add(auctionRecord);
                    await _context.SaveChangesAsync();

                    // Update auction
                    auction.StartingPrice = bidPrice;
                    _context.Update(auction);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true });
                }
                return Json(new { isValid = false, status = "Please bid at least " + minBid + " !" });
            }
            return Json(new { isValid = false, status = "You are currently not logged in !" });
        }

        public async Task<IActionResult> Cart()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var products = await _context.Carts.Where(e => e.UserId.Equals(user.Id)).Select(e => e.Product).ToListAsync();
                return View(products);
            }
            return View();
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

        public async Task<IActionResult> AddOrRemoveFavorites(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var myFavorites = await _context.MyFavorites.FindAsync(new object[] { user.Id, id });
                if (myFavorites == null)
                {
                    _context.Add(new MyFavorites() { UserId = user.Id, ProductId = id });
                    await _context.SaveChangesAsync();
                    return Json(new { like = true, id = id, status = "You have liked this product !" });
                }
                _context.Remove(myFavorites);
                await _context.SaveChangesAsync();
                return Json(new { like = false, id = id, status = "You have unliked this product !" });
            }
            return Json(new { like = false, id = 0, status = "Please login to continue !" });
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        public void SetTimer()
        {
            Timer t = new Timer(1000);
            t.Elapsed += OnTimedEvent;
            t.AutoReset = true;
            t.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                CheckAuctionExpired(context);
            }
        }

        public void CheckAuctionExpired(ApplicationDbContext context)
        {
            var auctionList = context.Auctions.ToList();
            foreach (var item in auctionList)
            {
                if (item.Status == false && item.StartDay.Value.CompareTo(DateTime.Now) < 0)
                {
                    item.Status = true;
                    context.Update(item);
                    context.SaveChanges();
                }
                if (item.Status == true && item.ClosingDay.Value.CompareTo(DateTime.Now) < 0)
                {
                    item.Status = false;
                    context.Update(item);
                    context.SaveChanges();
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
