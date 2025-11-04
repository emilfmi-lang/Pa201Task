using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    internal interface IBookService
    {
        void AddBook(Book book);
        List<Book> GetAllBooks();
        Book GetBook(int id);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
