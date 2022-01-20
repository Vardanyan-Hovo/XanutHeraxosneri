using Microsoft.EntityFrameworkCore;

namespace XanutHeraxosneri.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Apranq> ApranqnerDb{ get; set; }
        public DbSet<Category> CategoryDb { get; set; }
        public DbSet<Cart> cartsDb { get; set; }
        public DbSet<Order> ordersDb { get; set; }
        public DbSet<People> PeoplesDb { get; set; }



    }
}
