using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? NumOfStock { get; set; }
        public string? ImgUrl { get; set; }
        [ForeignKey("Id")]
        public Category Category { get; set; }
        [ForeignKey("Id")]
        public Brand Brand { get; set; }


    }
}
