using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class BookQuantity
    {
        public int Id { get; set; }
        public int BookId { get; set; } //т.к. устанолен внешний ключ, в таблице не будет дублей книг
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }

    public class BookQuantityConfiguration : IEntityTypeConfiguration<BookQuantity>
    {
        public void Configure(EntityTypeBuilder<BookQuantity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }

}
