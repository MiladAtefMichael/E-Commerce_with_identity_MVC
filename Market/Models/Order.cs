using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("Id")]
        public Product Product { get; set; }
        public DateTime Time { get; set; }
    }
}
