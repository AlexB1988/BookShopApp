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
using BookShopApp.Logging;

namespace BookShopApp
{
    public partial class CreateSaleForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly ISaleBookService _saleBookService;
        private readonly IGetLastCartDetails _getLastCartDetails;
        private readonly IRemoveUnsoldCartsService _removeUnsoldCartsService;
        private readonly ILoggerService<CreateSaleForm> _loggerService;
        public CreateSaleForm(ISaleBookService saleBookService, IGetLastCartDetails getLastCartDetails, IRemoveUnsoldCartsService removeUnsoldCartsService, ILoggerService<CreateSaleForm> loggerService)
        {
            InitializeComponent();
            _saleBookService = saleBookService;
            _getLastCartDetails = getLastCartDetails;
            _removeUnsoldCartsService = removeUnsoldCartsService;
            _loggerService = loggerService;
        }
        private void CreatePurchaseForm_Load(object sender, EventArgs e)
        {
            var selectedBooks = _getLastCartDetails.GetCartDetails();
            foreach (var book in selectedBooks)
            {
                book.CountBooksToSell = 1;
            }
            gridControlPurchaseBook.DataSource = selectedBooks;
        }
        private void btnOkPuchaseBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetBookListView.RowCount > 0)
                {
                    _saleBookService.SaleBook(GetAllBooks());
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                $"{ex.Message}\n",
                $"{ex.GetType()}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnCancelPurchaseBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateSaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _removeUnsoldCartsService.RemoveUnsoldCarts();
        }

        private List<Book> GetAllBooks()
        {
            int rowIndex = 0;
            List<Book> selectedBooks = new();
            while (GetBookListView.IsValidRowHandle(rowIndex))
            {
                if (GetBookListView.GetRow(rowIndex) is not Book ChangePriceBook)
                {
                    continue;
                }
                selectedBooks.Add(ChangePriceBook);
                rowIndex++;
            }
            return selectedBooks;
        }
    }
}