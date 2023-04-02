using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Interfaces
{
    public interface ICreateCartService
    {
        public bool CreateCart(List<Book> listOfPuchaseBooks);
    }
}
