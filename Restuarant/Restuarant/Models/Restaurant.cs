using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Models
{
    internal class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int MaxTables { get; set; }
        public List<Reservation> Reservations { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Name} | {Location} | {MaxTables} ";
        }

    }
}
