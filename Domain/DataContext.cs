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
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<AuthorsBooks> AuthorsBooks => Set<AuthorsBooks>();
        public DbSet<Publisher> Publishers => Set<Publisher>();
        public DbSet<BookQuantity> BookQuantities => Set<BookQuantity>();
        public DbSet<Sales> Sales => Set<Sales>();
        public DbSet<CurrentPrice> CurrentPrice => Set<CurrentPrice>();
        public DbSet<BookPrice> BookPrice => Set<BookPrice>();
        public DbSet<CheckList> CheckList => Set<CheckList>();
        public DbSet<Cart> Cart => Set<Cart>();
        public DbSet<CartDetails> CartDetails => Set<CartDetails>();
        public DbSet<BookCheckCount> BookCheckCounts => Set<BookCheckCount>();
        public DbSet<BookToChange> BookToChange=>Set<BookToChange>();
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
