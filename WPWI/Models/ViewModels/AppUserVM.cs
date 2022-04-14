using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace WPWI.Models.ViewModels
{
    public class AppUserVM
    {
        [Required]
        [MinLength(1)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
            ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }


        [Required,DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Don't Match Password")]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }
    }
}
