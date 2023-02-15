using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace CandyShop.ViewModels.Product
{
    public class EditVM
    {

        public int Id { get; set; }

        [DisplayName("ImageUrl")]
        [Required(ErrorMessage = "This field is required!")]
        public string ImageUrl { get; set; }

        [DisplayName("PieceCount")]
        [Required(ErrorMessage = "This field is required!")]
        public int PieceCount { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "This field is required!")]
        public decimal Price { get; set; }

    }
}
