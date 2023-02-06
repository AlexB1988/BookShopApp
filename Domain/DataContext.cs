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
        public DbSet<QuantityAndCosts> QuantityAndCosts { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=BookShopDb");
        }

    }
}
