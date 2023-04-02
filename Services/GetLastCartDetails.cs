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
    public class GetLastCartDetails : IGetLastCartDetails
    {
        ILifetimeScope _lifetimeScope;
        public GetLastCartDetails(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public List<Book> GetCartDetails()
        {
            try
            {
                using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
                {
                    var books = new List<Book>();
                    var lastCart = _dataContext.Cart.Max(x => x.Id);
                    var cartDetails = _dataContext.CartDetails.Where(x => x.CartId == lastCart);
                    foreach (var detail in cartDetails)
                    {
                        books.Add(_dataContext.Books.Include(x => x.BookQuantity).Include(x => x.CurrentPrice).FirstOrDefault(x => x.Id == detail.BookId));
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
