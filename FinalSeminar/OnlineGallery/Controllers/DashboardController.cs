using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Controllers
{
    //[Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult MyBids()
        {
            return View();
        }

        public IActionResult WinningBids()
        {
            return View();
        }

        public IActionResult MyFavorites()
        {
            return View();
        }
    }
}
