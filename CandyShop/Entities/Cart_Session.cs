using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyShop.Entities
{
    public class Cart_Session
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }


    }
}
