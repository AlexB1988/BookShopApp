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
        public SaleBookService()
        {
        }
        public bool SaleBook(List<Book> bookList)
        {
            using (var _dataContext = new DataContext())
            {
                try
                {
                    var checkList = new CheckList
                    {
                        Sum = 0
                    };

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
                            MessageBox.Show(
                            $"{book.Name}\n" +
                            $"Кол-ва экземпляров данной \n" +
                            $"книги меньше, чем Вы запросили в чеке.\n" +
                            $"Вернитесь в чек и измените данные.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                            return false;
                        }
                    }
                    if (MessageBox.Show(
                        $"Сумма покупки:{checkList.Sum} руб.\n" +
                        $"Продолжить?",
                        "Уведомление",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                    {
                        _dataContext.SaveChanges();
                        MessageBox.Show(
                        $"Покупка ена сумму:{checkList.Sum} руб.\n" +
                        $"успешно совершена!",
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
                catch (Exception ex)
                {
                    MessageBox.Show(
                    $"{ex.Message}\n" +
                    $"{ex.InnerException}",
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
}
