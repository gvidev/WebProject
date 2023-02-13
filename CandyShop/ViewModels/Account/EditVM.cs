
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CandyShop.ViewModels.Account
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "This field is required!")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This field is required!")]
        public string LastName { get; set; }



    }
}
