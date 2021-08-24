using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Areas.Identity.Data;
using OnlineGallery.Data;
using OnlineGallery.Models;
using OnlineGallery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    [Authorize(Roles = "User")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        // GET: Dashboard/EditProfile/5
        [NoDirectAccess]
        public async Task<IActionResult> EditProfile(string id)
        {
            if (id == null || id.Equals(""))
            {
                return Redirect("~/Identity/Account/AccessDenied");
            }
            else
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        }

        // POST: Dashboard/EditProfile/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(string id, ApplicationUser user)
        {
            if (user.FullName == null || user.FullName.Equals(""))
            {
                ModelState.AddModelError("FullName", "Please enter your fullname");
            }
            if (user.Email == null || user.Email.Equals(""))
            {
                ModelState.AddModelError("Email", "Please enter your email");
            }
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                if (!user.Email.Equals(currentUser.Email))
                {
                    currentUser.Email = currentUser.UserName = user.Email;
                    currentUser.EmailConfirmed = false; 
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(currentUser);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = currentUser.Id, code = code, returnUrl = Url.Content("~/") },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(currentUser.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                }
                if (user.PhoneNumber != null && !user.PhoneNumber.Equals(currentUser.PhoneNumber))
                {
                    currentUser.PhoneNumber = user.PhoneNumber;
                    currentUser.PhoneNumberConfirmed = false;
                }
                currentUser.Address = user.Address;
                _context.Update(currentUser);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "Profile") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "EditProfile", user) });
        }

        public async Task<IActionResult> MyBids()
        {
            await _context.Products.ToListAsync();
            return View();
        }

        public IActionResult WinningBids()
        {
            return View();
        }

        public async Task<IActionResult> MyFavorites()
        {
            await _context.Auctions.ToListAsync();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var productIdList = _context.MyFavorites.Where(e => e.UserId == currentUser.Id).Select(e => e.ProductId).ToList();
            var productList = _context.Products.Where(e => productIdList.Contains(e.Id)).ToList();
            return View(productList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetImage(ApplicationUser user)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            Tools.RemoveImage(_webHostEnvironment, currentUser.Image);
            currentUser.Image = Tools.SaveImage(_webHostEnvironment, user.FileImage);
            _context.Update(currentUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
