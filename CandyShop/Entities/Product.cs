
using System.ComponentModel.DataAnnotations;

namespace CandyShop.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int PieceCount { get; set; }
        public decimal Price { get; set; }
    }
}
