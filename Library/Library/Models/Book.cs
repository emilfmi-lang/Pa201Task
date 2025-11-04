using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public List<Borrow> Borrows { get; set;}

        public override string ToString()
        {
            return $"{Id} | {Name} | {AuthorName} | {Price} | {StockCount} ";
        }
    }
}
