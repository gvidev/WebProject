using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CandyShop.ViewModels.Product
{
    public class EditVM
    {

        public int Id { get; set; }

        [DisplayName("PieceCount")]
        [Required(ErrorMessage = "This field is required!")]
        public int PieceCount { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "This field is required!")]
        public decimal Price { get; set; }

    }
}
