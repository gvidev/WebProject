using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CandyShop.ViewModels.Account
{
    public class LoginVM
    {

        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }


    }
}
