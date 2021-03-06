using Microsoft.EntityFrameworkCore;
using MyWeb.Models;


namespace MyWebApps.Data
{
    public class ApplicationDbContext : DbContext
    {
        //creating a constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
