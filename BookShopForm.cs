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
using Microsoft.EntityFrameworkCore;
using DevExpress.XtraReports.UI;
using BookShopApp.Services;
using BookShopApp.Interfaces;
using DevExpress.Utils.DirectXPaint;
using BookShopApp.Domain;

namespace BookShopApp
{
    public partial class BookShopForm : DevExpress.XtraEditors.XtraForm
    {
        IGetBookService _getBookService;
        IGetPublishersService _getPublishersService;
        IAddPublisherService _addPublisherService;
        IAddAuthorService _addAuthorService;
        IGetAuthorsService _getAuthorsService;
        IAddBookService _addBookService;
        IGetSelectedBooksService _getSelectedBooksService;
        ISaleBookService _saleBookService;
        IChangePriceService _changePriceService;
        DataContext _dataContext;
        public BookShopForm(IGetBookService getBookService,
                            IAddPublisherService addPublisherService,
                            IAddAuthorService addAuthorService,
                            IGetPublishersService getPublishersService,
                            IGetAuthorsService getAuthorsService,
                            IAddBookService addBookService,
                            IGetSelectedBooksService getSelectedBooksService,
                            ISaleBookService saleBookService,
                            IChangePriceService changePriceService,
                            DataContext dataContext)
        {
            InitializeComponent();
            _getBookService = getBookService;
            _addPublisherService = addPublisherService;
            _addAuthorService = addAuthorService;
            _getPublishersService = getPublishersService;
            _getAuthorsService = getAuthorsService;
            _addBookService = addBookService;
            _getSelectedBooksService = getSelectedBooksService;
            _saleBookService = saleBookService;
            _changePriceService= changePriceService;
            _dataContext= dataContext;
        }

        private void BookShop_Load(object sender, EventArgs e)
        {
            gridControlGetBookList.DataSource = _getBookService.GetBooks();
        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            var _getBooks = new GetBookService(_dataContext);
            gridControlGetBookList.DataSource = _getBooks.GetBooks();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddPublisherForm addPublisherForm = new AddPublisherForm(_addPublisherService,this);
            addPublisherForm.Show();

        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddAuthorForm addAuthorForm = new AddAuthorForm(_addAuthorService,this);
            addAuthorForm.Show();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddBookForm addBookForm = new AddBookForm(_addPublisherService, _addAuthorService, 
                                                    _getPublishersService,_getAuthorsService,
                                                    _addBookService,this);
            addBookForm.Show();
        }

        private void btnGetReports_Click(object sender, EventArgs e)
        {
            this.Enabled=false;
            ReportsForm reportsForm = new ReportsForm(this);
            reportsForm.Show();
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
            CreatePurchaseForm createPurchaseForm = new CreatePurchaseForm(listOfPuchaseBooks, _getSelectedBooksService, _saleBookService, this);
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
            ChangePriceForm changePriceForm = new ChangePriceForm(listOfPuchaseBooks, _getSelectedBooksService,_changePriceService,this);
            changePriceForm.Show();
        }
    }
}