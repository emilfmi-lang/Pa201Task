using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Models
{
    internal class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsUsed { get; set; } = false;

        public override string ToString()
        {
            return $"{Id} | {Price}";
        }
    }
}
