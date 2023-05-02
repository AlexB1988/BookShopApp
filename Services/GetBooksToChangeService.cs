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
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var books= _dataContext.Books.Include(x => x.BookToChange.Where(y => y.IsGhanged == false))
                      .Include(x => x.BookQuantity)
                      .Include(x => x.CurrentPrice).ToList();
                return books;
            }
        }
    }
}
