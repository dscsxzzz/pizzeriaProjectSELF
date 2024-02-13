using COLORADO.Data.Models;

namespace COLORADO.Data.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
    }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
