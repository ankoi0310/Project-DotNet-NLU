using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Areas.Identity.Data;
using OnlineGallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // post: user/delete/5
        [HttpPost, ActionName("Lockout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LockoutConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user.Status)
            {
                user.Status = false;
                await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(10));
            }
            else
            {
                user.Status = true;
                await _userManager.SetLockoutEndDateAsync(user, DateTime.Now);
            }
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", await _context.Users.ToListAsync()) });
        }
    }
}
