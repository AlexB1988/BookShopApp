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
        private readonly IGetLastCartDetailsSrvice _getLastCartDetails;
        private readonly IRemoveUnsoldCartsService _removeUnsoldCartsService;
        private readonly ILoggerService<CreateSaleForm> _loggerService;
        private readonly ICheckSaleSumService _checkSaleSumService;
        public CreateSaleForm(ISaleBookService saleBookService, IGetLastCartDetailsSrvice getLastCartDetails,
            IRemoveUnsoldCartsService removeUnsoldCartsService, ILoggerService<CreateSaleForm> loggerService, 
            ICheckSaleSumService checkSaleSumService)
        {
            InitializeComponent();
            _saleBookService = saleBookService;
            _getLastCartDetails = getLastCartDetails;
            _removeUnsoldCartsService = removeUnsoldCartsService;
            _loggerService = loggerService;
            _checkSaleSumService = checkSaleSumService;
        }
        private void CreatePurchaseForm_Load(object sender, EventArgs e)
        {
            gridControlPurchaseBook.DataSource = _getLastCartDetails.GetCartDetails();
        }
        private void btnOkPuchaseBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetBookListView.RowCount > 0)
                {
                    if (MessageBox.Show(
                        $"Сумма покупки:{_checkSaleSumService.CheckSaleSum(GetAllBooks())} руб.\n" +
                        $"Продолжить?",
                        "Уведомление",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                    {
                        if(_saleBookService.SaleBook(GetAllBooks()))
                        MessageBox.Show(
                        $"Покупка ена сумму:{_checkSaleSumService.CheckSaleSum(GetAllBooks())} руб.\n" +
                        $"успешно совершена!",
                        "Уведомление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    }
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
            _removeUnsoldCartsService.RemoveUnsoldCarts();
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