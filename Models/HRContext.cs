using Microsoft.EntityFrameworkCore;
using Onlineproducts.Models;

namespace Onlineproducts.Models
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options)
        {

        }
        public DbSet<producttype> producttypes { get; set; }
        public DbSet<productcategory> productcategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderreturn> Orderreturns { get; set; }
        public DbSet<Onlineproducts.Models.UserDetails> AspNetuser { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<Onlineproducts.Models.ContactUs> ContactUs { get; set; }




    }
}
