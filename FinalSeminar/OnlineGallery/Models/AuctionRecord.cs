﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    [Table("AuctionRecord")]
    public class AuctionRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Key]
        [DisplayName("Auction")]
        [Column("AuctionId", TypeName = "int")]
        public int? AuctionId { get; set; }
        [ForeignKey("AuctionId")]
        public Auction Auction { get; set; }

        [Key]
        [DisplayName("User")]
        [Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required(ErrorMessage = "- Price can not be empty")]
        [Column("BidPrice", TypeName = "int")]
        public int? BidPrice { get; set; }

        [Column("Day", TypeName = "date")]
        public DateTime? Day { get; set; }

        [Column("Qualified", TypeName = "bit")]
        public bool Qualified { get; set; }
    }
}
