using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Services
{
    public class CheckSaleSumService : ICheckSaleSumService
    {
        public decimal CheckSaleSum(List<Book> books)
        {
            decimal sumSale=0;
            foreach(var book in books)
            {
                sumSale += decimal.Parse((book.CurrentPrice.Price * book.CountBooksToSell).ToString());
            }
            return sumSale;
        }
    }
}
