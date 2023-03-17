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

namespace BookShopApp
{
    public partial class BookShopForm : DevExpress.XtraEditors.XtraForm
    {
        IGetBookService _getBookService;
        public BookShopForm(IGetBookService getBookService)
        {
            InitializeComponent();
            _getBookService=getBookService;
        }

        private void BookShop_Load(object sender, EventArgs e)
        {
            gridControlGetBookList.DataSource = _getBookService.GetBooks();
        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            gridControlGetBookList.DataSource = _getBookService.GetBooks();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            AddPublisherForm addPublisherForm = new AddPublisherForm();
            addPublisherForm.ShowDialog();

        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            AddAuthorForm addAuthorForm = new AddAuthorForm();
            addAuthorForm.ShowDialog();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
        }

        private void btnGetReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }
        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            GridView gridViewGetBooks = gridControlGetBookList.MainView as GridView;
            var selectedRows = gridViewGetBooks.GetSelectedRows();
            List<object> listOfPuchaseBooks = new List<object>();
            foreach (var row in selectedRows)
            {
                var bookToPurchase = gridViewGetBooks.GetRow(row);
                listOfPuchaseBooks.Add(bookToPurchase);
            }
            CreatePurchaseForm createPurchaseForm = new CreatePurchaseForm(listOfPuchaseBooks,this);
            createPurchaseForm.Show();
        }


        private void btnChangePrice_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            GridView gridViewGetBooks = gridControlGetBookList.MainView as GridView;
            var selectedRows = gridViewGetBooks.GetSelectedRows();
            List<object> listOfPuchaseBooks = new List<object>();
            foreach (var row in selectedRows)
            {
                var bookToPurchase = gridViewGetBooks.GetRow(row);
                listOfPuchaseBooks.Add(bookToPurchase);
            }
            ChangePriceForm changePriceForm = new ChangePriceForm(listOfPuchaseBooks,this);
            changePriceForm.Show();
        }
    }
}