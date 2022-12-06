using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectLapDay2.Models
{
    public class Day2DBContext :IdentityDbContext<ApplicationUser>
    {
        public Day2DBContext()
        {

        }
        public Day2DBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependant> Dependants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<login> logins { get; set; }
        public DbSet<WorkOn> WorkOn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.;Database=Day2ITIDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOn>().HasKey("Pid", "Eid");
            base.OnModelCreating(modelBuilder);
        }
    }
}
