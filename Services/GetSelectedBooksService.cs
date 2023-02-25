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
    public class GetSelectedBooksService:IGetSelectedBooksService
    {
        public GetSelectedBooksService()
        {
        }
        public List<Book> GetSelectedBooks(List<object> list)
        {
            List<Book> selectedBooks = new List<Book>();
            foreach (var book in list)
            {
                selectedBooks.Add(book as Book);
            }
            return selectedBooks;
        }
    }
}
