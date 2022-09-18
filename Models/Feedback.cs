using System.ComponentModel.DataAnnotations;

namespace Onlineproducts.Models
{
    public class Feedback
    {
        [Key]
        public string Username { get; set; }
        public string ratings { get; set; }
        public string Review { get; set; }
    }
}
