using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImgUrl { get; set; }
    }
}
