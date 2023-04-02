using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class BookToChange
    {
        
        public int Id { get; set; }
        public int BookId { get; set; }
        public int? OldQuantiy { get; set; }
        public int Quantity { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public Book Book { get; set; }
        public bool IsGhanged { get; set; } = false;
    }
    public class BookToChangeConfiguration : IEntityTypeConfiguration<BookToChange>
    {
        public void Configure(EntityTypeBuilder<BookToChange> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.ToTable("BookToChange");
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookToChange);
        }
    }
}
