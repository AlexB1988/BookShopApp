using Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Repositories.DataManager;
using BookShopApp.Domain.Repositories.Interfaces;
using BookShopApp.Interfaces;
using BookShopApp.Services;
using DevExpress.XtraSpreadsheet.Model;

namespace BookShopApp
{
    internal static class Program
    {
        public static IContainer Container;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Container = Configure();
            Application.Run(new BookShopForm(Container.Resolve<IGetBookService>(),
                                            Container.Resolve<IAddPublisherService>(),
                                            Container.Resolve<IAddAuthorService>(),
                                            Container.Resolve<IGetPublishersService>(),
                                            Container.Resolve<IGetAuthorsService>(),
                                            Container.Resolve<IAddBookService>(),
                                            Container.Resolve<IGetSelectedBooksService>(),
                                            Container.Resolve<ISaleBookService>(),
                                            Container.Resolve<IChangePriceService>(),
                                            Container.Resolve<DataContext>()));
        }

        static IContainer Configure()
        {
            var builder =new ContainerBuilder();
            builder.RegisterType<GetBookService>().As<IGetBookService>();
            builder.RegisterType<GetBookService>();
            builder.RegisterType<AddPublisherService>().As<IAddPublisherService>();
            builder.RegisterType<AddPublisherService>();
            builder.RegisterType<AddAuthorService>().As<IAddAuthorService>();
            builder.RegisterType<AddAuthorService>();
            builder.RegisterType<AddBookService>().As<IAddBookService>();
            builder.RegisterType<AddBookService>();
            builder.RegisterType<GetPublisherService>().As<IGetPublishersService>();
            builder.RegisterType<GetPublisherService>();
            builder.RegisterType<GetAuthorsService>().As<IGetAuthorsService>();
            builder.RegisterType<GetAuthorsService>();
            builder.RegisterType<GetSelectedBooksService>().As<IGetSelectedBooksService>();
            builder.RegisterType<GetSelectedBooksService>();
            builder.RegisterType<SaleBookService>().As<ISaleBookService>();
            builder.RegisterType<SaleBookService>();
            builder.RegisterType<ChangePriceService>().As<IChangePriceService>();
            builder.RegisterType<ChangePriceService>();
            builder.RegisterType<DataContext>();
            builder.RegisterType<BookShopForm>();
            return builder.Build();
        }
    }
}