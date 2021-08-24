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
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [DisplayName("Username")]
        [Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [DisplayName("Create Date")]
        [Column("CreateDate", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [DisplayName("Completion Date")]
        [Column("CompletionDate", TypeName = "datetime")]
        public DateTime? CompletionDate { get; set; }

        [DisplayName("Total Price")]
        [Column("TotalPrice", TypeName = "int")]
        public int TotalPrice { get; set; }

        [Column("Status", TypeName = "bit")]
        public bool Status { get; set; }
    }
}
