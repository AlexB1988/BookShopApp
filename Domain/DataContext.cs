using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public  class DataContext:DbContext
    {
        public DbSet<Author> Authors { get; set; } = null;
        public DbSet<Book> Books { get; set; } = null;
        public DbSet<AuthorsBooks> AuthorsBooks { get; set; } = null;
        public DbSet<Publisher> Publishers { get; set; } = null;
        public DbSet<BookQuantity> BookQuantities { get; set; } = null;
        public DbSet<Sales> Sales { get; set; }=null;
        public DbSet<CurrentPrice> CurrentPrice { get; set; } = null;
        public DbSet<BookPrice> BookPrice { get; set; } = null;
        public DbSet<CheckList> CheckList { get; set; } = null;
        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=C:\\Users\\bochi\\source\\repos\\BookShopApp\\BookShopDb");
        }
        //"DataSource=bin\\Debug\\net6.0-windows\\BookShopDb"
    }
}
