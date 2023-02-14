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
        public List<Book> GetPurchasedBooks(List<object> list);
        public IEnumerable<Author> GetAuthors();
        public IEnumerable<Publisher> GetPublishers();
        public Book GetBookById(int id);
        public IEnumerable<Book> GetBooksByAuthor(string name);
        public IEnumerable<Author> GetAuthorsOfBooks(int bookId);
        public IEnumerable<Book> GetBooksByPublisher(string name);
        public IEnumerable<Book> GetBookByName(string name);
        public bool AddBook(string Name, string year, string isbn, string quantity, string price, string publisherId,List<string> authorList);
        public bool AddPublisher(Publisher publisher);
        public bool AddAuthor(Author author);
        public bool SaleBook(List<object> list);
        public bool DeleteBook(int ID);
        public bool ChangeBookPrice(int Id, decimal price);
    }
}
