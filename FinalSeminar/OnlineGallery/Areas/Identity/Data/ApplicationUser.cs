using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace OnlineGallery.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column("FullName", TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [PersonalData]
        [Column("Image", TypeName = "nvarchar(450)")]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile FileImage { get; set; }
    }
}
