using Microsoft.EntityFrameworkCore;
using Restuarant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server=.;Database=RestaurantDb;Trusted_Connection=True;TrustServerCertificate=True;"
          );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
