using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Interfaces
{
    public interface IAddBookService
    {
        public bool AddBook(Book book, BookQuantity bookQuantity, BookPrice price,List<string> authorList);
    }
}
