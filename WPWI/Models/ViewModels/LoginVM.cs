using System.ComponentModel.DataAnnotations;

namespace WPWI.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
