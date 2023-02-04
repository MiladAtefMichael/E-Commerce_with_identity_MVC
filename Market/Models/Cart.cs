using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("Id")]
        public Product Product { get; set; }
    }
}
