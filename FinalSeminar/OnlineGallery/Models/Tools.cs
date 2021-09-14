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
            var productsHaveGallery = context.ProductImages.Where(e => !auctioningList.Contains(e.ProductId) && e.Product.Status).Select(e => e.Product).Distinct().ToList();
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
        public static bool IsWinner(ApplicationDbContext context, AuctionRecord record)
        {
            if ((!record.Auction.Status && record.Auction.ClosingDay.Value.CompareTo(DateTime.Now) < 0))
            {
                var lastRecord = context.AuctionRecords.Where(e => e.AuctionId.Value.Equals(record.AuctionId.Value)).OrderBy(e => e.Id).Last();
                return lastRecord.Equals(record);
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

        // Check if product has been sold
        public static bool IsSold(ApplicationDbContext context, int id)
        {
            var soldProducts = context.TransactionDetails.Select(e => e.ProductId).ToList();
            return soldProducts.Contains(id);
        }

        // Check if product has been sold before auction end
        public static bool IsSoldBeforeAuctionEnd(ApplicationDbContext context, int id)
        {
            context.Transactions.ToList();
            var product = context.Products.Find(id);
            if (!product.Status)
            {
                var transaction = context.TransactionDetails.Where(e => e.ProductId.Equals(id)).Select(e => e.Transaction).FirstOrDefault();
                return !transaction.Auctioned;
            }
            return false;
        }

        // Check if that user buy that product
        public static bool IsUserSold(ApplicationDbContext context, string userId, int productId)
        {
            var transactionId = context.TransactionDetails.Where(e => e.ProductId.Equals(productId)).Select(e => e.TransactionId).FirstOrDefault();
            var transaction = context.Transactions.Find(transactionId);
            return transaction.UserId.Equals(userId);
        }

        // OVERVIEW PER MONTH
        // Get registration amount
        public static int GetTotalRegistration(ApplicationDbContext context)
            => context.UserRoles.Where(e => e.RoleId.Equals("2")).Count();

        // Get this month sales
        public static decimal GetThisMonthSales(ApplicationDbContext context)
            => context.TransactionDetails.Where(e =>
                e.Transaction.CompletionDate.Value.Month.Equals(DateTime.Now.Month) &&
                e.Transaction.CompletionDate.Value.Year.Equals(DateTime.Now.Year) && e.Transaction.Status
            ).Count();

        // Get last month sales
        public static decimal GetLastMonthSales(ApplicationDbContext context)
            => context.TransactionDetails.Where(e => 
                e.Transaction.CompletionDate.Value.Month.Equals(DateTime.Now.Month - 1) &&
                e.Transaction.CompletionDate.Value.Year.Equals(DateTime.Now.Year) && e.Transaction.Status
            ).Count();

        // Get this month profit
        public static decimal GetThisMonthProfit(ApplicationDbContext context)
            => context.Transactions.Where(e =>
                e.CompletionDate.Value.Month.Equals(DateTime.Now.Month) &&
                e.CompletionDate.Value.Year.Equals(DateTime.Now.Year) && e.Status
            ).Select(e => e.TotalPrice).Sum();

        // Get last month profit
        public static decimal GetLastMonthProfit(ApplicationDbContext context)
            => context.Transactions.Where(e =>
                e.CompletionDate.Value.Month.Equals(DateTime.Now.Month - 1) &&
                e.CompletionDate.Value.Year.Equals(DateTime.Now.Year) && e.Status
            ).Select(e => e.TotalPrice).Sum();

        // Get sales rate
        public static decimal GetSalesRateCompareLastMonth(ApplicationDbContext context)
        {
            var thisMonthSales = GetThisMonthSales(context);
            var lastMonthSales = GetLastMonthSales(context);
            if (lastMonthSales == 0)
            {
                if (thisMonthSales > 0)
                {
                    return 100;
                }
                if (thisMonthSales == 0)
                {
                    return 0;
                }
            }
            return thisMonthSales * 100 / lastMonthSales;
        }

        // Get profit rate
        public static decimal GetProfitRateCompareLastMonth(ApplicationDbContext context)
        {
            var thisMonthProfit = GetThisMonthProfit(context);
            var lastMonthProfit = GetLastMonthProfit(context);
            if (lastMonthProfit == 0)
            {
                if (thisMonthProfit > 0)
                {
                    return 100;
                }
                if (thisMonthProfit == 0)
                {
                    return 0;
                }
            }
            return thisMonthProfit * 100 / lastMonthProfit;
        }
    }
}
