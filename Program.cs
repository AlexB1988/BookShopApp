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
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new BookShopForm());
        }
    }
}