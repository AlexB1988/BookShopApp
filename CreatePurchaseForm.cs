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
using BookShopApp.Domain.Repositories.Interfaces;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace BookShopApp
{
    public partial class CreatePurchaseForm : DevExpress.XtraEditors.XtraForm
    {
        IDataManager _dataManager;
        List<object> _selectedBooksList;
        public CreatePurchaseForm(IDataManager dataManager,List<object> list)
        {
            _dataManager= dataManager;
            _selectedBooksList = list;
            InitializeComponent();
        }
        private void CreatePurchaseForm_Load(object sender, EventArgs e)
        {
            var selectedBooks=_dataManager.GetPurchasedBooks(_selectedBooksList);
            foreach(var book in selectedBooks)
            {
                book.CountToPurchase = 1;
            }
            gridControlPurchaseBook.DataSource = selectedBooks;
            //BookShopForm form = new BookShopForm(_dataManager);
            //form.Enabled = false;
        }
        private void btnOkPuchaseBook_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                int rowIndex = 0;
                List<object> purchaseBook = new List<object>();
                while (gridView1.IsValidRowHandle(rowIndex))
                {
                    purchaseBook.Add(gridView1.GetRow(rowIndex));
                    rowIndex++;
                }

                bool result = _dataManager.SaleBook(purchaseBook);
                if (result)
                {
                    this.Close();
                }
            }
        }

        private void btnCancelPurchaseBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender,CellValueChangedEventArgs e)
        {
            var gridView=sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null) return;
            if (e.Column.Caption != "TotalSum") return;
            string cellValue = (int.Parse(e.Value.ToString())*decimal.Parse(gridView.GetRowCellValue(e.RowHandle, gridView.Columns["Price"]).ToString())).ToString();
            gridView.SetRowCellValue(e.RowHandle, gridView.Columns["TotalSum"], cellValue);
        }
    }
}