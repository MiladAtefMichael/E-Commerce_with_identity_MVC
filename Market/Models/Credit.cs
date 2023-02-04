using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models
{
    public class Credit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int  CreditNumber { get; set; }
        [Required]
        public string CreditName { get; set; }
        [Required]
        public int CVC { get; set; }
        [Required]
        public string EndDate { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
