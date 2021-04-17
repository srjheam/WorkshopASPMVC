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
    }
}
