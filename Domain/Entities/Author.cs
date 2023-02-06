using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<AuthorsBooks> AuthorsBooks { get; set; }


        public Author()
        {
            Books=new HashSet<Book>();
            AuthorsBooks=new List<AuthorsBooks>();
        }
    }

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Authors");
            builder.HasMany(x => x.Books)
                .WithMany(y => y.Authors)
                .UsingEntity<AuthorsBooks>(
                d=>d
                .HasOne(x => x.Book)
                .WithMany(y=>y.AuthorsBooks)
                .HasForeignKey(z=>z.BookId),
                d=>d
                .HasOne(x => x.Author)
                .WithMany(y => y.AuthorsBooks)
                .HasForeignKey(z => z.AuthorId),
                d =>
                {
                    d.HasKey(x => new { x.Id });
                    d.ToTable("AuthorsBooks");
                });
        }
    }
}
