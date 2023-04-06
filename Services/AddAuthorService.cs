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
    public class AddAuthorService:IAddAuthorService
    {
        ILifetimeScope _lifetimeScope;
        public AddAuthorService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public bool AddAuthor(Author author)
        {
            try
            {
                var scope = _lifetimeScope.BeginLifetimeScope();
                using (var _dataContext = scope.Resolve<DataContext>())
                {
                    var existsAuthor = _dataContext.Authors.Where(x => x.Name == author.Name);
                    if (existsAuthor.Count() > 0)
                    {
                        throw new Exception("Данный автор уже есть в базе");
                    }
                    else
                    {
                        _dataContext.Add(author);
                        _dataContext.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
