using Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using BookShopApp.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class GetLastCartDetailsService : IGetLastCartDetailsSrvice
    {
        ILifetimeScope _lifetimeScope;
        public GetLastCartDetailsService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public List<Book> GetCartDetails()
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var books = new List<Book>();
                var lastCart = _dataContext.Cart.Max(x => x.Id);
                var booksToSell = _dataContext.Books.Include(x => x.CartDetails.Where(y=>y.CartId==lastCart))
                    .Include(x => x.BookQuantity)
                    .Include(x => x.CurrentPrice);
                var cartDetails = _dataContext.CartDetails.Where(x => x.CartId == lastCart);
                books.AddRange(booksToSell);
                return books;
            }
        }
    }
}
