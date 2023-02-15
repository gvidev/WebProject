using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyShop.Entities
{
    public class Cart_Products
    {

        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart_Session Cart { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }


    }
}
