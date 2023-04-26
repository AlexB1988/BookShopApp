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
    public class CreateCartService : ICreateCartService
    {
        ILifetimeScope _lifetimeScope;
        public CreateCartService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public bool CreateCart(List<Book> books)
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var cart = new Cart()
                {
                    SumOfCheck = 0
                };
                _dataContext.Cart.Add(cart);
                var cartDetailList = new List<CartDetails>();
                foreach (var book in books)
                {
                    var bookTemp = _dataContext.Books.FirstOrDefault(x => x.Id == book.Id);
                    var cartDetail = new CartDetails()
                    {
                        Cart = cart,
                        Book = bookTemp
                    };
                    cartDetailList.Add(cartDetail);
                }

                _dataContext.CartDetails.AddRange(cartDetailList);
                _dataContext.SaveChanges();
            }
            return true;
         
        }
    }
}
