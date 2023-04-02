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
    public class GetPublisherService:IGetPublishersService
    {
        ILifetimeScope _lifetimeScope;
        public GetPublisherService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public List<Publisher> GetPublishers()
        {
            try
            {
                using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
                {
                    var publishers = _dataContext.Publishers.ToList();
                    return publishers;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
