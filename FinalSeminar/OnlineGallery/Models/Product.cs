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
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Required(ErrorMessage = "- Enter product name")]
        [Column("Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column("Image", TypeName = "nvarchar(450)")]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile FileImage { get; set; }

        [DisplayName("Default Price")]
        [Required(ErrorMessage = "- Invalid price")]
        [Range(1, double.MaxValue, ErrorMessage = "- Price must greater than 0")]
        [Column("DefaultPrice", TypeName = "int")]
        public int? DefaultPrice { get; set; }

        [Required(ErrorMessage = "- Choose condition")]
        [Column("Condition", TypeName = "nvarchar(50)")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "- Invalid year of manufacture")]
        [Range(1900, 2021, ErrorMessage = "- The year must be between 1900-2021")]
        [Column("Year", TypeName = "int")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "- Fill the fuel text")]
        [Column("Fuel", TypeName = "nvarchar(50)")]
        public string Fuel { get; set; }

        [Required(ErrorMessage = "- Please select hoose color.")]
        [Column("Color", TypeName = "nvarchar(50)")]
        public string Color { get; set; }

        [DisplayName("Mileage (miles)")]
        [Required(ErrorMessage = "- Mileage can not be null.")]
        [Range(1, double.MaxValue, ErrorMessage = "- Mileage must greater than 0")]
        [Column("Mileage", TypeName = "int")]
        public int? Mileage { get; set; }

        [Required(ErrorMessage = "- Enter the engine type.")]
        [Column("Engine", TypeName = "nvarchar(50)")]
        public string Engine { get; set; }

        [Required(ErrorMessage = "- Please select transmission.")]
        [Column("Transmission", TypeName = "nvarchar(50)")]
        public string Transmission { get; set; }

        [Required(ErrorMessage = "- Please set the number of doors")]
        [Range(1, int.MaxValue, ErrorMessage = "- The car must have at least 1 door")]
        [Column("Doors", TypeName = "int")]
        public int? Doors { get; set; }

        [Column("Description", TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column("Status", TypeName = "bit")]
        public bool Status { get; set; }

        public List<Auction> Auctions { get; set; }
    }
}
