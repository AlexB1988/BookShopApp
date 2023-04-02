using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class BookCheckCount
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int BookCount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }

    public class BookChreckCountConfiguration : IEntityTypeConfiguration<BookCheckCount>
    {
        public void Configure(EntityTypeBuilder<BookCheckCount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("BookCheckCount");
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookCheckCounts);
        }
    }
}
