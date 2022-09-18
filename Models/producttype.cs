using System.ComponentModel.DataAnnotations.Schema;

namespace Onlineproducts.Models
{
    public class producttype
    {
        public int id { get; set; }
        public string productname { get; set; }
        [ForeignKey("categ")]
        public int categID { get; set; }
        public productcategory? categ { get; set; }
        public float price { get; set; }
    }
}
