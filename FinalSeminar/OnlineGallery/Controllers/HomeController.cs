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
using OnlineGallery.Services;
using OnlineGallery.Entities;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace OnlineGallery.Controllers
{
    public class HomeController : Controller
    {
        private const int pageSize = 9;
        private readonly ApplicationDbContext _context;
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly EmailSettings _emailSettings;

        public HomeController(
            ApplicationDbContext context,
            DbContextOptions<ApplicationDbContext> options,
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
            IOptions<EmailSettings> emailSettings,
            IEmailSender emailSender)
        {
            _context = context;
            _options = options;
            _logger = logger;
            _userManager = userManager;
            _emailSettings = emailSettings.Value;
            _emailSender = emailSender;
            SetTimer();
        }

        public IActionResult Index()
        {
            _context.AuctionRecords.ToList();
            return View();
        }

        [Authorize(Roles = "User")]
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

        public async Task<IActionResult> RemoveAllCart()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _context.Carts.Where(e => e.User.Equals(user)).ToListAsync();
            if (cart.Count() > 0)
            {
                foreach (var item in cart)
                {
                    _context.Remove(item);
                    await _context.SaveChangesAsync();
                }
                return Json(new { remove = true, status = "Remove successfully !" });
            }
            return Json(new { remove = false, status = "An error has occurred !" });
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Checkout(int id)
        {
            await _context.Products.ToListAsync();
            // For Auction Checkout
            var products = await _context.TransactionDetails.Where(e => e.TransactionId.Equals(id)).Select(e => e.Product).ToListAsync();
            if (products.Count() > 0)
            {
                ViewBag.Id = id;
                HttpContext.Session.SetString("Products", JsonConvert.SerializeObject(products));
                return View(products);
            }

            // For Regular Checkout
            var user = await _userManager.GetUserAsync(User);
            products = await _context.Carts.Where(e => e.User.Equals(user)).Select(e => e.Product).ToListAsync();
            if (products.Count() > 0)
            {
                foreach (var product in products)
                {
                    if (!product.Status)
                    {
                        return View("Cart", products);
                    }
                }
                ViewBag.Id = 0;
                HttpContext.Session.SetString("Products", JsonConvert.SerializeObject(products));
                return View(products);
            }
            return View("Cart");
        }

        [Authorize(Roles = "User")]
        public IActionResult BuyNow(int id)
        {
            var product = _context.Products.Find(id);
            if (!product.Status)
            {
                return Redirect("~/AccessDenied");
            }
            List<Product> products = new List<Product> { product };
            ViewBag.Id = 0;
            HttpContext.Session.SetString("Products", JsonConvert.SerializeObject(products));
            return View("Checkout", products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ConfirmPayment(int id, Transaction transaction, string Address, string PhoneNumber)
        {
            // Update profile if receive
            var user = await _userManager.GetUserAsync(User);
            if (Address != null)
            {
                user.Address = Address;
            }
            if (PhoneNumber != null)
            {
                user.PhoneNumber = PhoneNumber;
            }
            _context.Update(user);
            await _context.SaveChangesAsync();

            // Confirm transaction
            if (id == 0)
            {
                transaction.UserId = _userManager.GetUserId(User);
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                var latestTransaction = _context.Transactions.OrderBy(e => e.Id).Last();
                var products = JsonConvert.DeserializeObject<List<Product>>(HttpContext.Session.GetString("Products"));
                foreach (var product in products)
                {
                    TransactionDetail detail = new() { TransactionId = latestTransaction.Id, ProductId = product.Id, Price = product.DefaultPrice.Value };
                    _context.Add(detail);
                    product.Status = false;
                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    // Confirm auction close if opening
                    var auction = _context.Auctions.Where(e => e.ProductId.Equals(product.Id)).FirstOrDefault();
                    if (auction != null && auction.Status)
                    {
                        AuctionRecord record = new() { AuctionId = auction.Id, UserId = user.Id, BidPrice = product.DefaultPrice.Value, Day = DateTime.Now };
                        _context.Add(record);
                        auction.Status = false;
                        _context.Update(auction);
                        await _context.SaveChangesAsync();
                    }
                }
                latestTransaction.CompletionDate = DateTime.Now;
                latestTransaction.Status = true;
                _context.Update(latestTransaction);
                _context.Carts.RemoveRange(_context.Carts.Where(e => e.UserId.Equals(_userManager.GetUserId(User)) && products.Contains(e.Product)).ToList());
                await _context.SaveChangesAsync();
            }
            else
            {
                // Confirm transaction complete
                transaction = _context.Transactions.Find(id);
                transaction.CompletionDate = DateTime.Now;
                transaction.Status = true;
                _context.Update(transaction);
                await _context.SaveChangesAsync();

                // Confirm product sold
                var products = JsonConvert.DeserializeObject<List<Product>>(HttpContext.Session.GetString("Products"));
                foreach (var product in products)
                {
                    product.Status = false;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Product(int page = 1, string show = "all")
        {
            IQueryable<Product> query = null;
            switch (show)
            {
                case "sale":
                    await _context.Auctions.Where(e => e.Status).ToListAsync();
                    query = _context.Products.Where(e => e.Status);
                    break;
                case "sold":
                    query = _context.TransactionDetails.Select(e => e.Product);
                    break;
                default:
                case "all":
                    await _context.Products.ToListAsync();
                    await _context.Auctions.Where(e => e.Status).ToListAsync();
                    query = _context.ProductImages.Select(e => e.Product).Distinct();
                    break;
            }
            decimal totalSize = await query.CountAsync();
            if (page < 1 || page > Math.Ceiling(totalSize / pageSize))
            {
                return Redirect("~/Identity/Account/AccessDenied");
            }
            ViewBag.CurrentPage = page;
            ViewBag.CurrentShow = show;
            ViewBag.TotalSize = query.Count();
            var products = await query.OrderByDescending(e => e.Status).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            return View(products);
        }

        // GET: Home/ProductDetail/1
        public async Task<IActionResult> ProductDetail(int id)
        {
            await _context.Auctions.Where(e => e.Status).ToListAsync();
            Product product = await _context.Products.FindAsync(id);
            return View(product);
        }

        public async Task<IActionResult> Auction(int page = 1, string show = "all")
        {
            await _context.AuctionRecords.ToListAsync();
            IQueryable<Auction> query = null;
            switch (show)
            {
                case "upcoming":
                    query = _context.Auctions.Where(e => e.StartDay.Value.CompareTo(DateTime.Now) > 0);
                    break;
                case "inprocess":
                    query = _context.Auctions.Where(e => e.Status);
                    break;
                case "ended":
                    query = _context.Auctions.Where(e => e.ClosingDay.Value.CompareTo(DateTime.Now) < 0);
                    break;
                default:
                case "all":
                    query = _context.Auctions.OrderByDescending(e => e.Id);
                    break;
            }
            if (query.Count() == 0)
            {
                return View();
            }
            ViewBag.CurrentPage = page;
            ViewBag.CurrentShow = show;
            ViewBag.TotalSize = query.Count();
            if (page < 1 || page > Math.Ceiling((decimal)query.Count() / pageSize))
            {
                return Redirect("~/Identity/Account/AccessDenied");
            }
            var auctions = await query.OrderByDescending(e => e.Status).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            return View(auctions);
        }

        // GET: Home/AuctionDetail/1
        public async Task<IActionResult> AuctionDetail(int id)
        {
            await _context.Users.ToListAsync();
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
            var cart = await _context.Carts.Where(e => e.User.Equals(user)).ToListAsync();
            if (user != null && cart.Count() > 0)
            {
                var products = await _context.Carts.Where(e => e.UserId.Equals(user.Id)).Select(e => e.Product).ToListAsync();
                return View(products);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string email, string password, string subject, string message)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add(new MailAddress(_emailSettings.Username));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = false;

                using (var smtpClient = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = email,
                        Password = password
                    };
                    smtpClient.Credentials = credential;
                    smtpClient.Host = _emailSettings.Host;
                    smtpClient.Port = _emailSettings.Port;
                    smtpClient.EnableSsl = _emailSettings.EnableSSL;

                    await smtpClient.SendMailAsync(mail);
                    return Json(new { isValid = true, status = "Successfully !!!" });
                };
            }
            catch
            {
                return Json(new { isValid = false, status = "Fail. Please try again !!!" });
            }
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }

        [Authorize(Roles = "User")]
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
        public async Task<IActionResult> SuccessRegistration()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null && user.EmailConfirmed)
            {
                return View("Index");
            }
            return View();
        }

        public void SetTimer()
        {
            System.Timers.Timer t = new System.Timers.Timer(1000);
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
                var product = context.Products.Find(item.ProductId);
                // Check product has been sold before auction end
                if (!product.Status && item.StartDay.Value.CompareTo(DateTime.Now) > 0)
                {
                    context.Remove(item);
                    context.SaveChanges();
                }
                else if (product.Status)
                {
                    if (!item.Status && item.ClosingDay.Value.CompareTo(DateTime.Now) > 0 && item.StartDay.Value.CompareTo(DateTime.Now) < 0)
                    {
                        // Open auction
                        item.Status = true;
                        context.Update(item);
                        context.SaveChanges();
                    }
                    if (item.Status && item.ClosingDay.Value.CompareTo(DateTime.Now) < 0)
                    {
                        // Close auction
                        item.Status = false;
                        context.Update(item);
                        context.SaveChanges();

                        // Check if not have transaction (bought yet)
                        if (context.TransactionDetails.Any(e => !e.ProductId.Equals(item.ProductId.Value)))
                        {
                            var userId = context.AuctionRecords.Where(e => e.AuctionId.Equals(item.Id)).Select(e => e.UserId).FirstOrDefault();
                            // Create new transaction
                            Transaction transaction = new() { UserId = userId, Auctioned = true, CreateDate = DateTime.Now, TotalPrice = product.DefaultPrice.Value };
                            context.Add(transaction);
                            context.SaveChanges();

                            // Create detail
                            int latestId = context.Transactions.OrderBy(e => e.Id).Select(e => e.Id).Last(); // Above transaction id
                            TransactionDetail detail = new() { TransactionId = latestId, ProductId = product.Id, Price = product.DefaultPrice.Value };
                            context.Add(detail);
                            context.SaveChanges();
                        }
                    }
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
