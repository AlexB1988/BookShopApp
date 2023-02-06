using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection <Book> Books { get; set; }

        public Publisher()
        {
            Books=new HashSet<Book>();
        }
    }

    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Publishers");
        }
    }
}
