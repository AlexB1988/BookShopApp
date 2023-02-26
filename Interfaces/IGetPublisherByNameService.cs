using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Interfaces
{
    public interface IGetPublisherByNameService
    {
        public Publisher GetPublisherByName(string name);
    }
}
