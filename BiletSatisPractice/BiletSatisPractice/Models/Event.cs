using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Models
{
    internal class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public decimal PriceE { get; set; }
        public List<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return $"{Name} | {Time} | {PriceE})";
        }
        
    }
}
