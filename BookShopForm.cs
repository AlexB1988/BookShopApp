using BookShopApp.Domain.Repositories.Interfaces;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp
{
    public partial class BookShopForm : DevExpress.XtraEditors.XtraForm
    {
        IDataManager _dataManager;
        public BookShopForm(IDataManager dataManager)
        {
            InitializeComponent();
            _dataManager = dataManager;
        }

        private void BookShop_Load(object sender, EventArgs e)
        {
            gridControlGetBookList.DataSource = _dataManager.GetBooks();
        }
        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            GridView gridViewGetBooks = gridControlGetBookList.MainView as GridView;
            var selectedRows=gridViewGetBooks.GetSelectedRows();
            List<object> listOfPuchaseBooks= new List<object>();
            foreach(var row in selectedRows )
            {
                var bookToPurchase = gridViewGetBooks.GetRow(row);
                listOfPuchaseBooks.Add(bookToPurchase);
            }
            CreatePurchaseForm createPurchaseForm=new CreatePurchaseForm(_dataManager,listOfPuchaseBooks);
            createPurchaseForm.Show();
        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            gridControlGetBookList.DataSource = _dataManager.GetBooks();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            AddPublisherForm addPublisherForm = new AddPublisherForm(_dataManager);
            addPublisherForm.Show();
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            AddAuthorForm addAuthorForm = new AddAuthorForm(_dataManager);
            addAuthorForm.Show();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm(_dataManager);
            addBookForm.Show();
        }
    }
}