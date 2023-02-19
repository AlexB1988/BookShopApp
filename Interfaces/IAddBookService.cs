using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Interfaces
{
    public interface IAddBookService
    {
        public bool AddBook(string name, string year, string isbn, string quantity, string price, string selectedPublisher, List<string> authorList);
    }
}
