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
    public class AddBookService : IAdBookInterface
    {
        DataContext _dataContext;
        public AddBookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool AddBook(string name, string year, string isbn, string quantity, string price, string selectedPublisher, List<string> authorList)
        {
            if (price.Contains("."))
            {
                price = price.Replace(".", ",");
            }
            if (name is null || name == "" || name == " " || int.TryParse(year, out var yearResult) == false
                            || int.TryParse(quantity, out var quantityResult) == false
                            || decimal.TryParse(price, out var priceResult) == false
                            || selectedPublisher is null || authorList is null)
            {
                MessageBox.Show(
                $"Некорректные данные\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            var publisherBook = _dataContext.Publishers.FirstOrDefault(x => x.Name == selectedPublisher);
            var newBook = new Book
            {
                Name = name,
                Year = int.Parse(year),
                Isbn = isbn,
                PublisherId = publisherBook.Id
            };
            _dataContext.Add(newBook);

            List<AuthorsBooks> authorsBooksList = new List<AuthorsBooks>();
            foreach (var author in authorList)
            {
                var authorToAdd = _dataContext.Authors.FirstOrDefault(x => x.Id == int.Parse(author));
                var authorsBooks = new AuthorsBooks
                {
                    Book = newBook,
                    Author = authorToAdd,
                };
                authorsBooksList.Add(authorsBooks);
            }
            _dataContext.AddRange(authorsBooksList);

            var bookQuantity = new BookQuantity
            {
                Book = newBook,
                Quantity = int.Parse(quantity)
            };
            _dataContext.Add(bookQuantity);

            var currentPrice = new CurrentPrice
            {
                Books = newBook,
                Price = decimal.Parse(price)
            };
            _dataContext.CurrentPrice.Add(currentPrice);

            var bookPrice = new BookPrice
            {
                Books = newBook,
                Price = decimal.Parse(price),
                DateBegin = DateTime.UtcNow
            };
            _dataContext.BookPrice.Add(bookPrice);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
