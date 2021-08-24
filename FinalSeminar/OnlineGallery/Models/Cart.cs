using OnlineGallery.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DisplayName("Username")]
        [Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Key]
        [DisplayName("Product")]
        [Column("ProductId", TypeName = "int")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
