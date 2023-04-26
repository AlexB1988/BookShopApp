using Autofac;
using BookShopApp.Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using DevExpress.XtraBars.Alerter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class SaleBookService:ISaleBookService
    {
        ILifetimeScope _lifetimeScope;
        public SaleBookService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public bool SaleBook(List<Book> bookList)
        {
            using (var _dataContext = _lifetimeScope.Resolve<DataContext>())
            {
                var checkList = new CheckList
                {
                    Sum = 0
                };
                var lastCart = _dataContext.Cart.Max(x => x.Id);
                var cart =_dataContext.Cart.FirstOrDefault(x=>x.Id==lastCart);
                _dataContext.CheckList.Add(checkList);

                foreach (var book in bookList)
                {

                    var bookQuantity = _dataContext.BookQuantities.FirstOrDefault(x => x.BookId == book.Id);

                    int quantityToPurchase = int.Parse(book.CountBooksToSell.ToString());

                    if (bookQuantity.Quantity >= quantityToPurchase)
                    {
                        bookQuantity.Quantity -= quantityToPurchase;

                        var currentPrice = _dataContext.BookPrice.FirstOrDefault(x => x.BookId == book.Id && x.DateEnd == null);

                        checkList.Sum += (currentPrice.Price * quantityToPurchase);

                        for (int i = 0; i < quantityToPurchase; i++)
                        {
                            var sales = new Sales
                            {
                                PriceId = currentPrice.Id,
                                CheckList = checkList
                            };
                            _dataContext.Sales.Add(sales);
                        }
                    }
                    else
                    {
                        throw new Exception("Кол-во экземпляров книги \n" +
                            "меньше, чем Вы запросили в чекею\n" +
                            "Вернитесь в чек и измените данные");
                    }
                }
                cart.SumOfCheck = checkList.Sum;
                cart.IsSold = true;
                _dataContext.SaveChanges();
                return true;
            }
        }
    }
}
