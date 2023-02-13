using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CandyShop.ViewModels.Account
{
    public class EditPasswordVM
    {
        public int Id { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "This field is required!")]
        public string NewPassword { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }

        [DisplayName("Repeat Password")]
        [Required(ErrorMessage = "This field is required!")]
        [Compare("Password", ErrorMessage = "Passwords doesn't match!")]
        public string RepeatedPasword { get; set; }
    }
}
