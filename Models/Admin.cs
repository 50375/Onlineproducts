using System.ComponentModel.DataAnnotations;

namespace Onlineproducts.Models
{
    public class Admin
    {
        [Key]
        public string Adminname { get; set; }
        public string Adminpassword { get; set; }
    }
}
