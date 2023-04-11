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
    public class AddPublisherService:IAddPublisherService
    {
        ILifetimeScope _lifetimeScope;
        public AddPublisherService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public bool AddPublisher(Publisher publisher)
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var existsPublisher = _dataContext.Publishers.Where(x => x.Name == publisher.Name);
                if (existsPublisher.Count() > 0)
                {
                    throw new Exception("Данный издатель уже есть в базе");
                }
                else
                {
                    _dataContext.Add(publisher);
                    _dataContext.SaveChanges();
                    return true;
                }
            }

        }
    }
}
