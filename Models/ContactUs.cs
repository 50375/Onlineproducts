using System.ComponentModel.DataAnnotations;

namespace Onlineproducts.Models
{
    public class ContactUs
    {
        [Key]
        public int Contacnumber { get; set; }
        public string Mailid { get; set; }
    }
}
