using BookShopApp.Domain;
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
        DataContext _dataContext;
        public GetAuthorsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Domain.Entities.Author> GetAuthors()
        {
            var authors = _dataContext.Authors.ToList();
            return authors;
        }
    }
}
