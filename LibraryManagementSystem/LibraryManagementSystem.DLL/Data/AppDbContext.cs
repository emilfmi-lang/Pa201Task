

using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DLL.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Book> Books {  get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
             "Server=.;Database=LibraryManagementSystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
         );
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
