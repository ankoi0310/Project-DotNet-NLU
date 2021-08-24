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
    [Table("TransactionDetail")]
    public class TransactionDetail
    {
        [Key]
        [DisplayName("Transaction Id")]
        [Column("TransactionId", TypeName = "int")]
        public int TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }

        [Key]
        [DisplayName("Product Id")]
        [Column("ProductId", TypeName = "int")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Price { get; set; }
    }
}
