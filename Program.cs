using Autofac;
using BookShopApp.Autofac;
using BookShopApp.Domain;
using BookShopApp.Interfaces;
using BookShopApp.Services;
using DevExpress.XtraSpreadsheet.Model;
using NLog;
using System.CodeDom;
using System.Diagnostics;

namespace BookShopApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHAndler;

            ApplicationConfiguration.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();

            using var container = builder.Build();

            var form = container.Resolve<BookShopForm>();
            Application.Run(form);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Do logging
            ShowExceptionDetails(e.Exception);
        }

        static void UnhandledExceptionHAndler(object sender, UnhandledExceptionEventArgs e)
        {
            ShowExceptionDetails(e.ExceptionObject as Exception);
        }

        static void ShowExceptionDetails(Exception e)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Error(e);
            MessageBox.Show(e.Message, e.GetType().ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}