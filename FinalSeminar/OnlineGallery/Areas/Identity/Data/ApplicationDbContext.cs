using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineGallery.Areas.Identity.Data;
using OnlineGallery.Models;

namespace OnlineGallery.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyFavorites>().HasKey(r => new { r.UserId, r.ProductId });
            builder.Entity<AuctionRecord>().HasKey(r => new { r.Id, r.AuctionId, r.UserId });
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionRecord> AuctionRecords { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<MyFavorites> MyFavorites { get; set; }
    }
}
