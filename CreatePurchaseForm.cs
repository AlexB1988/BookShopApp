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
using BookShopApp.Interfaces;
using BookShopApp.Autofac;

namespace BookShopApp
{
    public partial class CreatePurchaseForm : DevExpress.XtraEditors.XtraForm
    {
        List<object> _selectedBooksList;
        IGetSelectedBooksService _getSelectedBooksService;
        ISaleBookService _saleBookService;
        BookShopForm _bookShopForm;
        public CreatePurchaseForm(List<object> list,BookShopForm bookShopForm)
        {
            InitializeComponent();
            _bookShopForm= bookShopForm;
            _selectedBooksList = list;
            _getSelectedBooksService= InstanceFactory.GetInstance<IGetSelectedBooksService>();
            _saleBookService= InstanceFactory.GetInstance<ISaleBookService>();
        }
        private void CreatePurchaseForm_Load(object sender, EventArgs e)
        {
            var selectedBooks=_getSelectedBooksService.GetSelectedBooks(_selectedBooksList);
            foreach(var book in selectedBooks)
            {
                book.CountBooksToSell = 1;
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
                bool result = _saleBookService.SaleBook(purchaseBook);
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

        //private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        //{
        //    if (gridView1.FocusedColumn.FieldName== "CountBooksToSell")
        //    {
        //        int count = 0;
        //        if(!int.TryParse(e.Value as String,out count))
        //        {
        //            e.Valid = false;
        //            e.ErrorText = "Значение колонки должно иметь целое положительное значение";
        //            this.Close();
        //        }
        //        else if (count <= 0)
        //        {
        //            e.Valid = false;
        //            e.ErrorText = "Значение колонки должно иметь целое положительное значение";
        //            this.Close();
        //        }
        //    }
        //}

        //private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        //{
        //    MessageBox.Show(this,e.ErrorText,"Неверное значение",MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    this.Close();
        //}
    }
}