using LibraryManagementSystem.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<OrderItem> Items { get; set; }

    }
}
