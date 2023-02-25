using Autofac;
using BookShopApp.Domain;
using BookShopApp.Interfaces;
using BookShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Autofac
{
    internal class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetBookService>().As<IGetBookService>();
            builder.RegisterType<AddPublisherService>().As<IAddPublisherService>();
            builder.RegisterType<AddAuthorService>().As<IAddAuthorService>();
            builder.RegisterType<AddBookService>().As<IAddBookService>();
            builder.RegisterType<GetPublisherService>().As<IGetPublishersService>();
            builder.RegisterType<GetAuthorsService>().As<IGetAuthorsService>();
            builder.RegisterType<GetSelectedBooksService>().As<IGetSelectedBooksService>();
            builder.RegisterType<SaleBookService>().As<ISaleBookService>();
            builder.RegisterType<ChangePriceService>().As<IChangePriceService>();
        }
    }
}
