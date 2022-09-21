using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace e_Tikets.Models
{
    public class ApplicatoinUser:IdentityUser
    {
        [Display(Name="Full Name")]
        public string FullName { get; set; }
    }
}
