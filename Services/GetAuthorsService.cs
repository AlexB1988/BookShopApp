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
    public class GetAuthorsService:IGetAuthorsService
    {
        ILifetimeScope _lifetimeScope;
        public GetAuthorsService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public List<Author> GetAuthors()
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var authors = _dataContext.Authors.ToList();
                return authors;
            }
        }
    }
}
