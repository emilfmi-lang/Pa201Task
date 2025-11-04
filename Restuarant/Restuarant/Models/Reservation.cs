using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TableCount { get; set; }
        public bool Used { get; set; } = false;
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Date} | {TableCount} | {Used}";
        }
    }
}
