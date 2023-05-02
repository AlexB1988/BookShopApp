using Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class ChangeCountBooksService : IChangeCountBooksService
    {
        private readonly ILifetimeScope _lifetimeScope;

        public ChangeCountBooksService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public bool ChangeCountBooks(List<Book> books)
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                foreach(var book in books)
                {
                    var currentBook = _dataContext.Books.Include(c => c.BookQuantity).FirstOrDefault(x => x.Id == book.Id);
                    if (currentBook.BookQuantity.Quantity + book.CountBooksToSell <0)
                    {
                        throw new Exception("Невозможно списать больше книг, чем имеется на складе");
                        return false;
                    }

                    currentBook.BookQuantity.Quantity += int.Parse(book.CountBooksToSell.ToString());
                    var bookCheckCounts = new BookCheckCount()
                    {
                        Book=currentBook,
                        BookCount= int.Parse(book.CountBooksToSell.ToString())
                    };
                    _dataContext.BookCheckCounts.Add(bookCheckCounts);
                    var bookToChange = _dataContext.BookToChange.FirstOrDefault(x => x.IsGhanged == false && x.BookId == currentBook.Id);
                    bookToChange.Quantity = bookCheckCounts.BookCount;
                    bookToChange.IsGhanged = true;
                    _dataContext.SaveChanges();
                }
                return true;
            }
        }
    }
}
