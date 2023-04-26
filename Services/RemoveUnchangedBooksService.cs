using Autofac;
using BookShopApp.Domain;
using BookShopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class RemoveUnchangedBooksService : IRemoveUnchangedBooksService
    {
        ILifetimeScope _lifetimeScope;
        public RemoveUnchangedBooksService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public void RemoveUnchangedBooks()
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var bookList = _dataContext.BookToChange.Where(x => x.IsGhanged == false);
                _dataContext.RemoveRange(bookList);
                _dataContext.SaveChanges();
            }
        }
    }
}
