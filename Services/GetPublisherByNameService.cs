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
        public GetPublisherByNameService()
        {
        }
        
        public Publisher GetPublisherByName(string name)
        {
            using( var _dataContext=new DataContext())
            {
                var publisher = _dataContext.Publishers.FirstOrDefault(x=>x.Name==name);
                return publisher;
            }
        }
    }
}
