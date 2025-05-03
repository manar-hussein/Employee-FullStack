using Microsoft.EntityFrameworkCore;

namespace Employee.InfraStructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee.Models.Employee> Employees { get; set; }
        public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
