using Microsoft.EntityFrameworkCore;

namespace CarWashSystemAPI.Models
{
    public class CarWashContext : DbContext
    {
        public CarWashContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
