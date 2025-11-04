using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class Borrow
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public Book book { get; set; }
        public bool IsReturned { get; set; }

        public override string ToString()
        {
            return $"{Id} | {BorrowDate} | {ReturnDate} | {BookId} | {IsReturned} ";
        }
    }
}
