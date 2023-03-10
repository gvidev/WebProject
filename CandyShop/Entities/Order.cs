using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace CandyShop.Entities
{
    public class Order
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
