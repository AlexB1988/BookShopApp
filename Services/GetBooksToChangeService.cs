using Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using DevExpress.Utils.Win.Hook;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class GetBooksToChangeService : IGetBooksToChangeService
    {
        ILifetimeScope _lifetimeScope;
        public GetBooksToChangeService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public List<Book> GetBooksToChange()
        {
            try
            {
                using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
                {
                    var books = new List<Book>();
                    var booksToChange = _dataContext.BookToChange.Where(x => x.IsGhanged == false).ToList();

                    foreach (var bookToChange in booksToChange)
                    {
                        books.Add(_dataContext.Books.Include(x => x.BookQuantity).Include(x => x.CurrentPrice).FirstOrDefault(x => x.Id == bookToChange.BookId));
                    }
                    return books;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
