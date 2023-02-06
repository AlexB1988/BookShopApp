using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public decimal PriceId { get; set; }
        public BookPrice Prices{ get; set; }
    }

    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Sales");
            builder.HasOne(x => x.Prices)
                .WithMany(x => x.Sales)
                .HasForeignKey(x=>x.PriceId);
        }
    }
}
