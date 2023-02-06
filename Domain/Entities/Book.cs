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
        public Publisher Publisher { get; set; }
        public QuantityAndCosts? QuantityAndCosts { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<AuthorsBooks> AuthorsBooks { get; set; }

        public Book()
        {
            Authors=new HashSet<Author>();
            AuthorsBooks=new List<AuthorsBooks>();
        }
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
