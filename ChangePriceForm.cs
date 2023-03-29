using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;
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
        List<Book> _selectedBooksList=new();
        private readonly IChangePriceService _changePriceService;
        public ChangePriceForm(IChangePriceService changePriceService)
        {
            InitializeComponent();
            _changePriceService = changePriceService;
        }
        public void AddBooks(Book book)
        {
            _selectedBooksList.Add(book);
        }

        private void ChangePriceForm_Load(object sender, EventArgs e)
        {
            foreach (var book in _selectedBooksList)
            {
                book.PriceOfBooksToChange = 0;
            }
            gridControlChangePrice.DataSource = _selectedBooksList;
        }


        private void btnCancelChangePrice_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkChangePrice_Click(object sender, EventArgs e)
        {
            if (gridView1_1.RowCount > 0)
            {
                this.Enabled = false;


                int rowIndex = 0;
                List<Book> selectedBooks = new List<Book>();
                while (gridView1_1.IsValidRowHandle(rowIndex))
                {
                    if(gridView1_1.GetRow(rowIndex) is not Book ChangePriceBook)
                    {
                        continue;
                    }
                    selectedBooks.Add(ChangePriceBook);
                }
                //var selectedBooks = _getSelectedBooksService.GetSelectedBooks(selectedObjectBooks);
                bool result = _changePriceService.ChangePrice(selectedBooks);
            }
            this.Close();
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