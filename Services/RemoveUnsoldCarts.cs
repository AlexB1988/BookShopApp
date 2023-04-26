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
    internal class RemoveUnsoldCartsService : IRemoveUnsoldCartsService
    {
        ILifetimeScope _lifetimeScope;
        public RemoveUnsoldCartsService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public void RemoveUnsoldCarts()
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var carts = _dataContext.Cart.Where(x => x.IsSold == false);
                foreach (var cart in carts)
                {
                    ;            var cartDetails = _dataContext.CartDetails.Where(x => x.CartId == cart.Id);
                    _dataContext.CartDetails.RemoveRange(cartDetails);
                }
                _dataContext.Cart.RemoveRange(carts);
                _dataContext.SaveChanges();
            }
        }
    }
}
