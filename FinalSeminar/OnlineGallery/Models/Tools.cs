using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineGallery.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineGallery.Models
{
    public static partial class Tools
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

        // If product have been auctioned, this function will return that auction 
        public static Auction GetAuctionFromProduct(ApplicationDbContext context, int productId)
            => context.Auctions.Where(e => e.ProductId == productId).FirstOrDefault();

        // 
        public static bool CheckGalleryProduct(ApplicationDbContext context, int productId)
            => context.ProductImages.Any(e => e.ProductId == productId);

        // Product List Have Gallery
        public static List<Product> GetProductIdHaveGallery(ApplicationDbContext context)
            => context.ProductImages.Select(e => e.Product).ToList();

        // 
        public static List<string> GetProductImages(ApplicationDbContext context, int productId)
            => context.ProductImages.Where(e => e.ProductId == productId).Select(e => e.Image).ToList();
    }
}
