using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Interfaces
{
    public interface IGetBookService
    {
        public IEnumerable<Book> GetBooks();
        //public IEnumerable<Domain.Entities.Author> GetAuthorsOfBooks(int bookId);
    }
}
