using BookShopApp.Domain.Entities;
using BookShopApp.Domain.Repositories.Interfaces;
using DevExpress.XtraReports.Templates;
using DevExpress.XtraSpreadsheet.Model;
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




        public bool ChangeBookPrice(int Id, decimal price)
        {
            if (decimal.TryParse(price.ToString(),out var result))
            {
                var oldBookPrice = _dataContext.BookPrice.FirstOrDefault(x => x.BookId == Id && x.DateEnd == null);
                if (oldBookPrice is null)
                {
                    return false;
                }
                oldBookPrice.DateEnd = DateTime.UtcNow;
                var newBookPrice = new BookPrice
                {
                    BookId=Id,
                    Price = price,
                    DateBegin=DateTime.UtcNow
                };
                _dataContext.Add(newBookPrice);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteBook(int Id)
        {
            var sales = _dataContext.Sales.Include(x => x.Price).Where(x=>x.Price.BookId==Id);
            if (sales is null)
            {
                //Прописать проверку на наличие продаж по книге 
                //а также на удаление из BookPrice
                var quantityBook = _dataContext.BookQuantities.Where(x => x.BookId == Id);
                _dataContext.RemoveRange(quantityBook);
                var book = _dataContext.Books.FirstOrDefault(x => x.Id == Id);
                _dataContext.Books.Remove(book);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
