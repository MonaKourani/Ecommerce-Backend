using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options) { 
        
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
