using BiletSatisPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Data
{
    internal class TicketDbContext:DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server=.;Database=ITicketDB;Trusted_Connection=True;TrustServerCertificate=True;"
          );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
