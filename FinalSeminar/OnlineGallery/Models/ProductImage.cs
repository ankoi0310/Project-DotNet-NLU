using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [DisplayName("Product")]
        [Required(ErrorMessage = "- Please select product.")]
        [Column("ProductId", TypeName = "int")]
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [DisplayName("Image Name")]
        [Column("Image", TypeName = "nvarchar(450)")]
        public string Image { get; set; }
        [NotMapped]
        public List<IFormFile> FileImage { get; set; }
    }
}
