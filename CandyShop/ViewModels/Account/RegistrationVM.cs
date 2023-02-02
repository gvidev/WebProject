using CandyShop.ActionFilters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CandyShop.ViewModels.Account
{
    public class RegistrationVM
    {

        [DisplayName("Username")]
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }

        [DisplayName("Repeat Password")]
        [Required(ErrorMessage = "This field is required!")]
        [Compare("Password", ErrorMessage = "Passwords doesn't match!")]
        public string RepeatedPasword { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "This field is required!")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This field is required!")]
        public string LastName { get; set; }

        

    }
}

