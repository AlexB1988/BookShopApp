using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class CheckList
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime DateOfCheck { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}
