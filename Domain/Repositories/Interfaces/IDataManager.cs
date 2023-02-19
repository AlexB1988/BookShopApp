using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Repositories.Interfaces
{
    public interface IDataManager
    {
        public Book GetBookById(int id);
        public IEnumerable<Book> GetBooksByAuthor(string name);
        public IEnumerable<Book> GetBooksByPublisher(string name);
        public IEnumerable<Book> GetBookByName(string name);
        public bool DeleteBook(int ID);
    }
}
