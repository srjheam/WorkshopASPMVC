using Microsoft.EntityFrameworkCore;
using WorkshopASPMVC.Models;

namespace WorkshopASPMVC.Data
{
    public class WorkshopContext : DbContext
    {
        public WorkshopContext (DbContextOptions<WorkshopContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
