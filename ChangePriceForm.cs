using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using BookShopApp.Logging;
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
        private readonly IChangePriceService _changePriceService;
        private readonly IGetBooksToChangeService _getBooksToChangeService;
        private readonly IRemoveUnchangedBooksService _removeUnchangedBooksService;
        private readonly ILoggerService<ChangePriceForm> _loggerService;
        public ChangePriceForm(IChangePriceService changePriceService, IGetBooksToChangeService getBooksToChangeService, 
                                IRemoveUnchangedBooksService removeUnchangedBooksService, ILoggerService<ChangePriceForm> loggerService)
        {
            InitializeComponent();
            _changePriceService = changePriceService;
            _getBooksToChangeService = getBooksToChangeService;
            _removeUnchangedBooksService = removeUnchangedBooksService;
            _loggerService = loggerService;
        }

        private void ChangePriceForm_Load(object sender, EventArgs e)
        {
            gridControlChangePrice.DataSource = _getBooksToChangeService.GetBooksToChange();
        }


        private void btnCancelChangePrice_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkChangePrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetBookListView.RowCount > 0)
                {
                    if (_changePriceService.ChangePrice(GetAllBooks()))
                    {
                        MessageBox.Show(
                        $"Цены успешно изменены\n",
                        $"Уведомление",
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
                _loggerService.Error(ex);
                MessageBox.Show(
                $"{ex.Message}\n",
                $"{ex.GetType()}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
            }
        }

        private void ChangePriceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _removeUnchangedBooksService.RemoveUnchangedBooks();
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