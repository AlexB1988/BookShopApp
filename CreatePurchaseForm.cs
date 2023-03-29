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
using System.Windows.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using BookShopApp.Interfaces;
using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;

namespace BookShopApp
{
    public partial class CreatePurchaseForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly ISaleBookService _saleBookService;
        public List<Book> _selectedBooksList = new();
        public CreatePurchaseForm(ISaleBookService saleBookService)
        {
            InitializeComponent();
            _saleBookService = saleBookService;
        }

        public void AddBooks(Book book)
        {
            _selectedBooksList.Add(book);
        }
        private void CreatePurchaseForm_Load(object sender, EventArgs e)
        {
            var selectedBooks = _selectedBooksList;
            foreach (var book in selectedBooks)
            {
                book.CountBooksToSell = 1;
            }
            gridControlPurchaseBook.DataSource = selectedBooks;
        }
        private void btnOkPuchaseBook_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                int rowIndex = 0;
                List<Book> purchaseBook = new List<Book>();
                while (gridView1.IsValidRowHandle(rowIndex))
                {
                    if(gridView1.GetRow(rowIndex) is not Book purchaseObjectBook)
                    {
                        continue;
                    }
                    purchaseBook.Add(purchaseObjectBook);
                    //purchaseBook.Add(gridView1.GetRow(rowIndex) as Book);
                    rowIndex++;
                }
                //var purchaseBook = _getSelectedBooksService.GetSelectedBooks(purchaseObjectBook);
                bool result = _saleBookService.SaleBook(purchaseBook);
            }
            this.Close();
        }

        private void btnCancelPurchaseBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}