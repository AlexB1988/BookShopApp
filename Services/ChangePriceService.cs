using Autofac;
using BookShopApp.Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class ChangePriceService:IChangePriceService
    {
        ILifetimeScope _lifetimeScope;
        public ChangePriceService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public bool ChangePrice(List<Book> bookList)
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                foreach (var book in bookList)
                {
                    var currentBook = _dataContext.Books.Include(x => x.CurrentPrice).FirstOrDefault(x => x.Id == book.Id);
                    if (decimal.Parse(book.PriceOfBooksToChange.ToString()) <= 0)
                    {
                        throw new Exception("Цена должна иметь\n положительное значение");
                    }

                    currentBook.CurrentPrice.Price = decimal.Parse(book.PriceOfBooksToChange.ToString());

                    var currentPrice = _dataContext.BookPrice.FirstOrDefault(x => x.BookId == currentBook.Id && x.DateEnd == null);
                    currentPrice.DateEnd = DateTime.UtcNow;

                    var newPrice = new BookPrice
                    {
                        Books = currentBook,
                        Price = decimal.Parse(book.PriceOfBooksToChange.ToString()),
                        DateBegin = DateTime.UtcNow
                    };

                    _dataContext.BookPrice.Add(newPrice);
                    var bookToChange = _dataContext.BookToChange.FirstOrDefault(x => x.IsGhanged == false && x.BookId == currentBook.Id);
                    bookToChange.Price = newPrice.Price;
                    bookToChange.IsGhanged = true;
                }
                if (MessageBox.Show(
                   $"Применить изменения?",
                   "Уведомление",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    _dataContext.SaveChanges();
                    MessageBox.Show(
                    $"Цены успешно изменены",
                    "Уведомление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
    }
}
