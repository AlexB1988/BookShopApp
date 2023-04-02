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
    public class CreateBookListToChangeService : ICreateBookListToChangeService
    {
        ILifetimeScope _lifetimeScope;
        public CreateBookListToChangeService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public void CreateBookListToChange(List<Book> books)
        {
            try
            {
                using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
                {
                    foreach (var book in books)
                    {
                        var bookTemp = _dataContext.Books.FirstOrDefault(x => x.Id == book.Id);
                        var bookToChange = new BookToChange()
                        {
                            Book = bookTemp,
                            OldQuantiy = book.BookQuantity.Quantity,
                            OldPrice = book.CurrentPrice.Price
                        };
                        _dataContext.BookToChange.Add(bookToChange);
                    }
                    _dataContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
