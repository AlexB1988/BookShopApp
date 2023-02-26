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
    public class AddBookService : IAddBookService
    {
        public AddBookService()
        {
        }
        public bool AddBook(Book book, BookQuantity quantity, BookPrice price,List<string> authorList)
        {
            try
            {
                using (var _dataContext = new DataContext())
                {
                    _dataContext.Books.Add(book);
                    _dataContext.BookQuantities.Add(quantity);
                    _dataContext.BookPrice.Add(price);

                    List<AuthorsBooks> authorsBooksList = new List<AuthorsBooks>();
                    foreach (var author in authorList)
                    {
                        var authorToAdd = _dataContext.Authors.FirstOrDefault(x => x.Id == int.Parse(author));
                        var authorsBooks = new AuthorsBooks
                        {
                            Book = book,
                            Author = authorToAdd,
                        };
                        authorsBooksList.Add(authorsBooks);
                    }
                    _dataContext.AuthorsBooks.AddRange(authorsBooksList);

                    var currentPrice = new CurrentPrice
                    {
                        Books = book,
                        Price = price.Price
                    };
                    _dataContext.CurrentPrice.Add(currentPrice);

                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(
                $"{e.InnerException}\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
        }
    }
}
