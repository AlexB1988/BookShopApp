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
        BookShopForm _bookShopForm;
        public CreatePurchaseForm(IDataManager dataManager,List<object> list,BookShopForm bookShopForm)
        {
            InitializeComponent();
            _bookShopForm= bookShopForm;
            _dataManager = dataManager;
            _selectedBooksList = list;
        }
        private void CreatePurchaseForm_Load(object sender, EventArgs e)
        {
            var selectedBooks=_dataManager.GetPurchasedBooks(_selectedBooksList);
            foreach(var book in selectedBooks)
            {
                book.CountOrPrice = 1;
            }
            gridControlPurchaseBook.DataSource = selectedBooks;
            //BookShopForm form = new BookShopForm(_dataManager);
            //form.Enabled = false;
        }
        private void btnOkPuchaseBook_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                this.Enabled = false;


                int rowIndex = 0;
                List<object> purchaseBook = new List<object>();
                while (gridView1.IsValidRowHandle(rowIndex))
                {
                    purchaseBook.Add(gridView1.GetRow(rowIndex));
                    rowIndex++;
                }
                bool result = _dataManager.SaleBook(purchaseBook);
            }
            _bookShopForm.Enabled = true;

            this.Close();
        }

        private void btnCancelPurchaseBook_Click(object sender, EventArgs e)
        {
            this.Close();
            _bookShopForm.Enabled = true;
        }

        private void CreatePurchaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bookShopForm.Enabled = true;
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName== "CountOrPrice")
            {
                int count = 0;
                if(!int.TryParse(e.Value as String,out count))
                {
                    e.Valid = false;
                    e.ErrorText = "Значение колонки должно иметь целое положительное значение";
                }
                else if (count <= 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Значение колонки должно иметь целое положительное значение";
                }
            }
        }

        private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            MessageBox.Show(this,e.ErrorText,"Неверное значение",MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
    }
}