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
        DataContext _dataContext;
        public GetPublisherService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Domain.Entities.Publisher> GetPublishers()
        {
            var publishers = _dataContext.Publishers.ToList();
            return publishers;
        }
    }
}
