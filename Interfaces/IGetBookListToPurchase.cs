using BookShopApp.Domain.Entities;
using BookShopApp.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Interfaces
{
    public interface IGetBookListToPurchase
    {
        public void AddBooks(Book book);
    }
}
