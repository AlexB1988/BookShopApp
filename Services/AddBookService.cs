using Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class AddBookService : IAddBookService
    {
        ILifetimeScope _lifetimeScope;
        public AddBookService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public bool AddBook(Book book, BookQuantity quantity, BookPrice price,List<string> authorList)
        {
            try
            {
                using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
                {
                    _dataContext.Books.Add(book);
                    _dataContext.BookQuantities.Add(quantity);
                    _dataContext.BookPrice.Add(price);

                    var authorsBooksList = new List<AuthorsBooks>();
                    foreach (var author in authorList)
                    {
                        var authorToAdd = _dataContext.Authors.FirstOrDefault(x => x.Id == int.Parse(author));
                        var authorsBooks = new AuthorsBooks
                        {
                            Book = book,
                            Author = authorToAdd,
                        };
                        authorsBooksList.Add(authorsBooks);
                    }
                    _dataContext.AuthorsBooks.AddRange(authorsBooksList);

                    var currentPrice = new CurrentPrice
                    {
                        Books = book,
                        Price = price.Price
                    };
                    _dataContext.CurrentPrice.Add(currentPrice);

                    var bookCheckCount=new BookCheckCount()
                    {
                        Book=book,
                        BookCount=quantity.Quantity
                    };
                    _dataContext.BookCheckCounts.Add(bookCheckCount);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
