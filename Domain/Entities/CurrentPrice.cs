using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public  class CurrentPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; set; } 
        public Book Books { get; set; }
    }

    public class CurrentPriceConfiguration : IEntityTypeConfiguration<CurrentPrice>
    {

        public void Configure(EntityTypeBuilder<CurrentPrice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CurrentPrice");
        }
    }
}
