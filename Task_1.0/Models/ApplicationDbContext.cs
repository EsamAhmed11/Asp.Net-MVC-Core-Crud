using Microsoft.EntityFrameworkCore;

namespace Task_1._0.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Option):base(Option)
        {
        }

        public virtual DbSet<Product>  Products { get; set; }
        public virtual DbSet<Supplier>  Suppliers { get; set; }

        
    }
}
