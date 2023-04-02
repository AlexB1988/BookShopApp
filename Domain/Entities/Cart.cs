using DevExpress.XtraRichEdit.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal SumOfCheck { get; set; }
        public DateTime DateOfCart { get; set; }=DateTime.UtcNow;
        public bool IsSold { get; set; } = false; 
        public ICollection<CartDetails> CartDetails { get; set; }
    }

    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Cart");
        }
    }
}
