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
        public IQueryable<Book> GetBooks();
        public Book GetBookById(int id);
        public IQueryable<Book> GetBooksByAuthor(string name);
        public IQueryable<Author> GetAuthorsOfBooks(Book book);
        public IQueryable<Book> GetBooksByPublisher(string name);
        public IQueryable<Book> GetBookByName(string name);
        public bool AddBook(Book book);
        public bool SaleBook(Book book);
        public bool DeleteBook(Book book);
        public bool ChangeBookPrice(Book book, decimal price);
    }
}
