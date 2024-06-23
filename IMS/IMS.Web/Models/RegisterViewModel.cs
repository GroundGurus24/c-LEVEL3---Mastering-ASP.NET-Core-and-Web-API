using System.ComponentModel.DataAnnotations;

namespace IMS.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Your Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="The Password and Confirmationdoes not match.")]
        public string ConfirmPassword { get; set;}
    }
}
