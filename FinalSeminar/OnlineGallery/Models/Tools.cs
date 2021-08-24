using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Areas.Identity.Data;
using OnlineGallery.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    public partial class Tools
    {
        // Save Image To Folder
        public static string SaveImage(IWebHostEnvironment webHostEnvironment, IFormFile image)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            fileName = fileName + "-" + DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
            string path = Path.Combine(wwwRootPath + "/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return fileName;
        }

        // Remove Image From Folder
        public static void RemoveImage(IWebHostEnvironment webHostEnvironment, string image)
        {
            if (image != null)
            {
                var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }

        // 
        public static bool CheckGalleryProduct(ApplicationDbContext context, int productId)
            => context.ProductImages.Any(e => e.ProductId.Equals(productId));

        // Product List Have Gallery
        public static List<Product> GetProductNotAuctioned(ApplicationDbContext context)
        {
            var auctioningList = context.Auctions.Where(e => e.Status || e.StartDay.Value.CompareTo(DateTime.Now) > 0).Select(e => e.ProductId).ToList();
            var productsHaveGallery = context.ProductImages.Where(e => !auctioningList.Contains(e.ProductId)).Select(e => e.Product).Distinct().ToList();
            return productsHaveGallery;
        }

        // 
        public static List<string> GetProductImages(ApplicationDbContext context, int productId)
            => context.ProductImages.Where(e => e.ProductId.Equals(productId)).Select(e => e.Image).ToList();

        // Check My Favorites
        public static bool IsMyFavorites(ApplicationDbContext context, string userId, int productId)
        {
            return context.MyFavorites.Any(e => e.UserId.Equals(userId) && e.ProductId.Equals(productId));
        }

        // Get the winner
        public static bool IsWinner(ApplicationDbContext context, int? auctionId, string userId)
        {
            var auction = context.Auctions.Find(auctionId);

            if (!auction.Status && auction.ClosingDay.Value.CompareTo(DateTime.Now) < 0)
            {
                var recentAuctionRecord = context.AuctionRecords.Find(auctionId, userId);
                var lastAuctionRecord = context.AuctionRecords.Where(e => e.AuctionId.Equals(auctionId)).Last();
                return recentAuctionRecord.Equals(lastAuctionRecord);
            }
            return false;
        }

        // Check true if product is in cart, otherwise false
        public static bool IsInCart(ApplicationDbContext context, string userId, int productId)
        {
            return context.Carts.Any(e => e.UserId.Equals(userId) && e.ProductId.Equals(productId));
        }

        // Check if user have cart
        public static bool IsHaveCart(ApplicationDbContext context, string userId)
        {
            return context.Carts.Any(e => e.UserId.Equals(userId));
        }
    }
}   
