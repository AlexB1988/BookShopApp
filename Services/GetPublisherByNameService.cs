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
    public class GetPublisherByNameService:IGetPublisherByNameService
    {
        ILifetimeScope _lifetimeScope;
        public GetPublisherByNameService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public Publisher GetPublisherByName(string name)
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var publisher = _dataContext.Publishers.FirstOrDefault(x => x.Name == name);
                return publisher;
            }

        }
    }
}
