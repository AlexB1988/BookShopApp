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
        public GetPublisherService()
        {
        }

        public IEnumerable<Domain.Entities.Publisher> GetPublishers()
        {
            using (var _dataContext = new DataContext())
            {
                var publishers = _dataContext.Publishers.ToList();
                return publishers;
            }
        }
    }
}
