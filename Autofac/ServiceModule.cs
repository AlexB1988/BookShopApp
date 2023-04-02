using Autofac;
using Autofac.Builder;
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
            builder.RegisterType<SaleBookService>().As<ISaleBookService>();
            builder.RegisterType<ChangePriceService>().As<IChangePriceService>();
            builder.RegisterType<GetPublisherByNameService>().As<IGetPublisherByNameService>();
            builder.RegisterType<CreateCartService>().As<ICreateCartService>();
            builder.RegisterType<GetLastCartDetails>().As<IGetLastCartDetails>();
            builder.RegisterType<RemoveUnsoldCartsService>().As<IRemoveUnsoldCartsService>();
            builder.RegisterType<CreateBookListToChangeService>().As<ICreateBookListToChangeService>();
            builder.RegisterType<GetBooksToChangeService>().As<IGetBooksToChangeService>();
            builder.RegisterType<RemoveUnchangedBooksService>().As<IRemoveUnchangedBooksService>();
            builder.RegisterType<DataContext>().AsSelf();
            builder.RegisterType<AddPublisherForm>().AsSelf();
            builder.RegisterType<AddAuthorForm>().AsSelf();
            builder.RegisterType<AddBookForm>().AsSelf();
            builder.RegisterType<ChangePriceForm>().AsSelf();
            builder.RegisterType<CreateSaleForm>().AsSelf();
            builder.RegisterType<BookShopForm>();
            builder.RegisterType<ReportsForm>().AsSelf();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AssignableTo<DevExpress.XtraEditors.XtraForm>()
                .AsSelf();
        }
    }
}
