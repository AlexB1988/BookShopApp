using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Interfaces
{
    public interface IGetSelectedBooksService
    {
        public List<Book> GetSelectedBooks(List<object> list);
    }
}
