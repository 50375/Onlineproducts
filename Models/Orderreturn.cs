using System.ComponentModel.DataAnnotations;

namespace Onlineproducts.Models
{
    public class Orderreturn
    {
        [Key]
        public int      OrderId { get; set; }
        public string   OrderName { get; set; }
       
    }
}
