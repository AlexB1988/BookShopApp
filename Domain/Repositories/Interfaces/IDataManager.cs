using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Repositories.Interfaces
{
    public interface IDataManager
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBookById(int id);
        public IEnumerable<Book> GetBooksByAuthor(string name);
        public IEnumerable<Author> GetAuthorsOfBooks(Book book);
        public IEnumerable<Book> GetBooksByPublisher(string name);
        public IEnumerable<Book> GetBookByName(string name);
        public bool AddBook(Book book);
        public bool AddPublisher(Publisher publisher);
        public bool AddAuthor(Author author);
        public bool SaleBook(Book book);
        public bool DeleteBook(Book book);
        public bool ChangeBookPrice(Book book, decimal price);
    }
}
