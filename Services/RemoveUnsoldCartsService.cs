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
                var cartsToRemove = _dataContext.Cart.Where(x => x.IsSold == false)
                        .Include(x=>x.CartDetails);

                _dataContext.Cart.RemoveRange(cartsToRemove);
                _dataContext.SaveChanges();
            }
        }
    }
}
