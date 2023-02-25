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
        public GetAuthorsService()
        {
        }

        public IEnumerable<Domain.Entities.Author> GetAuthors()
        {
            using (var _dataContext = new DataContext())
            {
                var authors = _dataContext.Authors.ToList();
                return authors;
            }
        }
    }
}
