
using Microsoft.AspNetCore.Identity;

namespace Market.Models
{
    public class User : IdentityUser
    {
        public decimal Charge { get; set; }
        public int? Age { get; set; }
        
    }
}
