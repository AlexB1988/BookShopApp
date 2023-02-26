using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Validation
{
    public class BookValid
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Isbn { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public object AuthorListString { get; set; }
    }
}
