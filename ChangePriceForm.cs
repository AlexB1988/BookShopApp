using BookShopApp.Autofac;
using BookShopApp.Interfaces;
using BookShopApp.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopApp
{
    public partial class ChangePriceForm : DevExpress.XtraEditors.XtraForm
    {
        List<object> _selectedBooksList;
        IGetSelectedBooksService _getSelectedBooksService;
        IChangePriceService _changePriceService;
        BookShopForm _bookShopForm;
        public ChangePriceForm(List<object> list,BookShopForm bookShopForm)
        {
            InitializeComponent();
            _selectedBooksList = list;
            _getSelectedBooksService = InstanceFactory.GetInstance<IGetSelectedBooksService>();
            _changePriceService=InstanceFactory.GetInstance<IChangePriceService>();
            _bookShopForm = bookShopForm;
        }

        private void ChangePriceForm_Load(object sender, EventArgs e)
        {
            var selectedBooks = _getSelectedBooksService.GetSelectedBooks(_selectedBooksList);
            foreach (var book in selectedBooks)
            {
                book.PriceOfBooksToChange = 0;
            }
            gridControlChangePrice.DataSource = selectedBooks;
        }

        private void ChangePriceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bookShopForm.Enabled = true;
        }

        private void btnCancelChangePrice_Click(object sender, EventArgs e)
        {
            this.Close();
            _bookShopForm.Enabled = true;
        }

        private void btnOkChangePrice_Click(object sender, EventArgs e)
        {
            if (gridView1_1.RowCount > 0)
            {
                this.Enabled = false;


                int rowIndex = 0;
                List<object> selectedBooks = new List<object>();
                while (gridView1_1.IsValidRowHandle(rowIndex))
                {
                    selectedBooks.Add(gridView1_1.GetRow(rowIndex));
                    rowIndex++;
                }
                bool result = _changePriceService.ChangePrice(selectedBooks);
            }
            this.Close();
            _bookShopForm.Enabled = true;
        }
        //private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        //{
        //    if (gridView1_1.FocusedColumn.FieldName == "PriceOfBooksToChange")
        //    {
        //        decimal count = 1.65m;
        //        if (!decimal.TryParse(e.Value as String, out count))
        //        {
        //            e.Valid = false;
        //            e.ErrorText = "Значение колонки должно иметь численное положительное значение";
        //            this.Close();
        //        }
        //        else if (count <= 0)
        //        {
        //            e.Valid = false;
        //            e.ErrorText = "Значение колонки должно иметь численное положительное значение";
        //            this.Close();
        //        }
        //        else
        //        {

        //        }
        //    }
        //}

        //private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        //{
        //    MessageBox.Show(this, e.ErrorText, "Неверное значение", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    this.Close();
        //}
    }
}