using Autofac;
using BookShopApp.Autofac;
using BookShopApp.Domain;
using BookShopApp.Interfaces;
using BookShopApp.Services;
using DevExpress.XtraSpreadsheet.Model;
using NLog;

namespace BookShopApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();

            using var container=builder.Build();
            var form=container.Resolve<BookShopForm>();
            Application.Run(form);
        }
    }
}