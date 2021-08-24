using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    [Table("Auction")]
    public class Auction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        [Column("ProductId", TypeName = "int")]
        [Required(ErrorMessage = "- Please select product.")]
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [DisplayName("Start Day (MM/dd/yyyy)")]
        [Column("StartDay", TypeName = "date")]
        public DateTime? StartDay { get; set; }

        [DisplayName("Closing Day (MM/dd/yyyy)")]
        [Column("ClosingDay", TypeName = "date")]
        public DateTime? ClosingDay { get; set; }

        [DisplayName("Starting Price")]
        [Required(ErrorMessage = "- Please set starting price for this auction")]
        [Range(1, Double.MaxValue, ErrorMessage = "- Starting price must be greater than 0")]
        [Integer(ErrorMessage = "- Please enter valid number")]
        [Column("StartingPrice", TypeName = "int")]
        public int? StartingPrice { get; set; }

        [DisplayName("Step Price")]
        [Required(ErrorMessage = "- Enter step price")]
        [Range(1, Double.MaxValue, ErrorMessage = "- Step price must be greater than 0")]
        [Integer(ErrorMessage = "- Please enter valid number")]
        [Column("StepPrice", TypeName = "int")]
        public int? StepPrice { get; set; }

        [Column("Status", TypeName = "bit")]
        public bool Status { get; set; }

        public List<AuctionRecord> AuctionRecords { get; set; }
    }
}
