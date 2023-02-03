using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CandyShop.ViewModels.Product
{
    public class CreateVM
    {

        [DisplayName("Category")]
        [Required(ErrorMessage = "This field is required!")]
        public string Category { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }

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
