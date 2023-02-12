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
        public int PriceId { get; set; }
        public BookPrice Price{ get; set; }
        public int CheckListId { get; set; }
        public CheckList CheckList { get; set; }
    }

    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Sales");
            builder.HasOne(x => x.Price)
                .WithMany(x => x.Sales)
                .HasForeignKey(x=>x.PriceId);
            builder.HasOne(x => x.CheckList)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CheckListId);
        }
    }
}
