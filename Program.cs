using Autofac;
using BookShopApp.Domain;
using BookShopApp.Domain.Repositories.DataManager;
using BookShopApp.Domain.Repositories.Interfaces;
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
            Application.Run(new BookShopForm(Container.Resolve<IDataManager>()));
        }

        static IContainer Configure()
        {
            var builder =new ContainerBuilder();
            builder.RegisterType<DataManager>().As<IDataManager>();
            builder.RegisterType<DataManager>();
            builder.RegisterType<DataContext>();
            builder.RegisterType<BookShopForm>();
            return builder.Build();
        }
    }
}