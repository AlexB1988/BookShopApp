using BookShopApp.Domain.Entities;
using BookShopApp.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Repositories.DataManager
{

    public class DataManager : IDataManager
    {
        public DataContext _dataContext;

        public DataManager(DataContext dataContext)
        {
            _dataContext=dataContext;
        }
        
        public IEnumerable<Book> GetBooks()
        {
            var books = _dataContext.Books.Include(x => x.Publisher)
                                          .Include(x => x.BookQuantity)
                                          .Include(x=>x.CurrentPrice)
                                          .ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _dataContext.Books.FirstOrDefault(x=>x.Id==id);
            return book;
        }

        public IEnumerable<Book> GetBooksByAuthor(string name)
        {
            var books = from bookList in _dataContext.Books
                        join authorsBooks in _dataContext.AuthorsBooks on bookList.Id equals authorsBooks.BookId
                        join authors in _dataContext.Authors on authorsBooks.AuthorId equals authors.Id
                        where authors.Name.Contains(name)
                        select(bookList);
            return books;
        }
        public IEnumerable<Author> GetAuthorsOfBooks(Book book)
        {
            var authorsList = from authors in _dataContext.Authors
                        join authorsBooks in _dataContext.AuthorsBooks on authors.Id equals authorsBooks.AuthorId
                        join books in _dataContext.Books on authorsBooks.BookId equals books.Id
                        where books.Id==book.Id
                        select (authors);
            return authorsList;
        }
        public IEnumerable<Book> GetBooksByPublisher(string name)
        {
            var books = _dataContext.Books.Include(x => x.Publisher).Where(x => x.Publisher.Name.Contains(name));
            return books;
        }
       public IEnumerable<Book> GetBookByName(string name)
        {
            var books = _dataContext.Books.Where(x => x.Name.Contains(name));
            return books;
        }
        public bool AddBook(Book book)
        {
            if(book is not null)
            {
                _dataContext.Books.Add(book);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddPublisher(Publisher publisher)
        {
            var existsPublisher = _dataContext.Publishers.FirstOrDefault(x => x.Name == publisher.Name);
            if (existsPublisher == null && publisher is not null)
            {


                if (publisher.Name != "" && publisher.Name is not null)
                {
                    _dataContext.Add(publisher);
                    _dataContext.SaveChanges();
                    return true;
                }
                MessageBox.Show(
                $"Некорректные данные\n" +
                $"Введите наименование издатнльства",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else
            {
                MessageBox.Show(
                $"Данный издатель уже есть в базе\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;

            }
        }

        public bool AddAuthor(Author author)
        {
            var existsAuthor = _dataContext.Authors.FirstOrDefault(x => x.Name == author.Name);
            if (existsAuthor != null)
            {
                MessageBox.Show(
                $"Данный автор уже есть в базе\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;

            }

            else if (author.Name == "" || author.Name is null)
            {
                MessageBox.Show(
                $"Некорректные данные\n" +
                $"Введите имя автора",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else
            {
                _dataContext.Add(author);
                _dataContext.SaveChanges();
                return true;
            }

        }

        public bool ChangeBookPrice(Book book, decimal price)
        {
            if (book is not null)
            {
                var oldBookPrice = _dataContext.BookPrice.FirstOrDefault(x => x.BookId == book.Id && x.DateEnd == null);
                if (oldBookPrice is null)
                {
                    return false;
                }
                oldBookPrice.DateEnd = DateTime.UtcNow;
                var newBookPrice = new BookPrice
                {
                    BookId=book.Id,
                    Price = price,
                    DateBegin=DateTime.UtcNow
                };
                _dataContext.Add(newBookPrice);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteBook(Book book)
        {
            if (book is not null)
            {
                //Прописать проверку на наличие продаж по книге 
                //а также на удаление из BookPrice
                var quantityBook = _dataContext.BookQuantities.Where(x => x.BookId == book.Id);
                _dataContext.RemoveRange(quantityBook);
                _dataContext.Books.Remove(book);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaleBook(Book book)
        {
            if (book is not null)
            {
                var bookQuantity = _dataContext.BookQuantities.FirstOrDefault(x => x.BookId == book.Id);
                if (bookQuantity.Quantity==0)
                {
                    return false;
                }
                bookQuantity.Quantity -= 1;

                var bookPrice = _dataContext.BookPrice.FirstOrDefault(x => x.BookId == book.Id && x.DateEnd == null);
                if(bookPrice is null)
                {
                    return false;
                }
                var newSale = new Sales
                {
                    PriceId = bookPrice.Id
                };
                _dataContext.Add(newSale);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
