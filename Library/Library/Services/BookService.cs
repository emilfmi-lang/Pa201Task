using Library.Data;
using Library.Interfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    internal class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var data = _context.Books.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                _context.Books.Remove(data);
            }
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(int id)
        {
            var data = _context.Books.Find(id);
            if(data == null)
            {
                Console.WriteLine("Kitab tapilmadi");
            }
            return data;
        }

        public void UpdateBook(Book book)
        {
            var data = _context.Books.Find(book.Id);
            if(data != null)
            {
                data.Name = book.Name;
                data.AuthorName = book.AuthorName;
                data.StockCount = book.StockCount;
            }
        }
    }
}
