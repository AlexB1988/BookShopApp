using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public  class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Isbn { get; set; }
        public int PublisherId { get; set; }
        public int? CountBooksToSell { get; set; } = 1;
        public decimal? PriceOfBooksToChange { get; set; } = 0;
        public string? AuthorsList { get; set; }
        public Publisher Publisher { get; set; }
        public BookQuantity? BookQuantity { get; set; }
        public CurrentPrice? CurrentPrice { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<BookPrice> Prices { get; set; }
        public ICollection<AuthorsBooks> AuthorsBooks { get; set; }

        public Book()
        {
            Prices=new HashSet<BookPrice>();
            Authors=new HashSet<Author>();
            AuthorsBooks=new List<AuthorsBooks>();
            //AuthorsList = GetAuthorsList();
        }


        //private string GetAuthorsList()
        //{
        //    string[] authors=new string[Authors.Count];
        //    int i = 0;
        //    foreach(Author author in Authors)
        //    {
        //        authors[i]=author.Name;
        //    }
        //    string stringAuthors=string.Join(", ",authors);
        //    return stringAuthors;
        //}
    }

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book>builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Books");
            builder.HasOne(d => d.Publisher)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PublisherId);
        }
    }
}
