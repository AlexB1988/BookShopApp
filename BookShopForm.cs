using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using BookShopApp.Services;
using BookShopApp.Interfaces;
using DevExpress.Utils.DirectXPaint;
using BookShopApp.Domain;
using BookShopApp.Autofac;
using Autofac;
using Autofac.Features.OwnedInstances;
using BookShopApp.Domain.Entities;
using NLog;
using BookShopApp.Logging;

namespace BookShopApp
{
    public partial class BookShopForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IGetBookService _getBookService;
        private readonly ICreateCartService _createCartService;
        private readonly ICreateBookListToChangeService _createBookListToChangeService;
        private readonly ILoggerService<BookShopForm> _loggerService;

        public BookShopForm(IGetBookService getBookService, ILifetimeScope lifetimeScope, ICreateCartService createCartService, ICreateBookListToChangeService createBookListToChangeService, ILoggerService<BookShopForm> loggerService)
        {
            InitializeComponent();
            _getBookService = getBookService;
            _lifetimeScope = lifetimeScope;
            _createCartService = createCartService;
            _createBookListToChangeService = createBookListToChangeService;
            _loggerService = loggerService;
        }

        private void BookShop_Load(object sender, EventArgs e)
        {
            gridControlGetBookList.DataSource = _getBookService.GetBooks();
            _loggerService.Info("The app is starting!!!");

        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            gridControlGetBookList.DataSource = _getBookService.GetBooks();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            using(var form = _lifetimeScope.Resolve<Owned<AddPublisherForm>>())
            {
                form.Value.ShowDialog();
            }
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            using (var form = _lifetimeScope.Resolve<Owned<AddAuthorForm>>())
            {
                form.Value.ShowDialog();
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var form = _lifetimeScope.Resolve<Owned<AddBookForm>>())
            {
                form.Value.ShowDialog();
            }
        }

        private void btnGetReports_Click(object sender, EventArgs e)
        {
            using(var form = _lifetimeScope.Resolve<Owned<ReportsForm>>())
            {
                form.Value.ShowDialog();
            }
        }
        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            var selectedRows = GetBookListView.GetSelectedRows();
            var listOfPuchaseBooks = new List<Book>();
            foreach (var row in selectedRows)
            {
                if(GetBookListView.GetRow(row) is not Book bookToPurchase)
                {
                    continue;
                }
                listOfPuchaseBooks.Add(bookToPurchase);
            }
            _createCartService.CreateCart(listOfPuchaseBooks);
            using (var form = _lifetimeScope.Resolve<Owned<CreateSaleForm>>())
            {
                form.Value.ShowDialog();
            }
        }
        private void btnChangePrice_Click(object sender, EventArgs e)
        {
            var selectedRows = GetBookListView.GetSelectedRows();
            var listOfPuchaseBooks = new List<Book>();
            foreach (var row in selectedRows)
            {
                if(GetBookListView.GetRow(row) is not Book bookToPurchase)
                {
                    continue;
                }
                listOfPuchaseBooks.Add(bookToPurchase);
            }
            _createBookListToChangeService.CreateBookListToChange(listOfPuchaseBooks);
            using(var form = _lifetimeScope.Resolve<Owned<ChangePriceForm>>())
            {
                form.Value.ShowDialog();
            }
        }

        private void BookShopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loggerService.Info("The app is closing");
        }
    }
}