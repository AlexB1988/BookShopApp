using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Books { get; set; }
        public decimal Price { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; } = null;
        public ICollection<Sales> Sales { get; set; }

        public BookPrice()
        {
            Sales=new HashSet<Sales>();
        }
    }

    public class BookPriceConfiguration : IEntityTypeConfiguration<BookPrice>
    {
        public void Configure(EntityTypeBuilder<BookPrice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("BookPrice");
            builder.HasOne(x=>x.Books)
                .WithMany(x=>x.Prices)
                .HasForeignKey(x=>x.BookId);
        }
    }
}
