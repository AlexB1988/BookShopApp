using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class CartDetails
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public Cart? Cart { get; set; }
        public Book? Book { get; set; }
    }

    public class CartDetailsConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CartDetails");
            //builder.HasOne(x => x.Book)
            //    .WithMany(x => x.CartDetails);
            builder.HasOne(x => x.Cart)
                .WithMany(x => x.CartDetails);
        }
    }
}
