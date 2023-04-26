using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using BookShopApp.Logging;
using DevExpress.Office.Drawing;
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

namespace BookShopApp
{
    public partial class AddCountBooksForm : DevExpress.XtraEditors.XtraForm
    {

        private readonly IGetBooksToChangeService _getBooksToChangeService;
        private readonly IRemoveUnchangedBooksService _removeUnchangedBooksService;
        private readonly IChangeCountBooksService _changeCountBooksService;
        private readonly ILoggerService<AddCountBooksForm> _loggerService;
        public AddCountBooksForm(IGetBooksToChangeService getBooksToChangeService, IRemoveUnchangedBooksService removeUnchangedBooksService, 
                                IChangeCountBooksService changeCountBooksService, ILoggerService<AddCountBooksForm> loggerService)
        {
            InitializeComponent();
            _getBooksToChangeService = getBooksToChangeService;
            _removeUnchangedBooksService = removeUnchangedBooksService;
            _changeCountBooksService = changeCountBooksService;
            _loggerService = loggerService;
        }

        private void AddCountBooksForm_Load(object sender, EventArgs e)
        {
            ChangeQuantityBooksGridControl.DataSource = _getBooksToChangeService.GetBooksToChange();
        }

        private void btnOkChangeCountBooks_Click(object sender, EventArgs e)
        {
            if (GetBookListView.RowCount > 0)
            {
                if (_changeCountBooksService.ChangeCountBooks(GetAllBooks()))
                {
                    MessageBox.Show(
                    $"Приход успешно добавлен",
                    $"Уведомление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            this.Close();
        }

        private void btnCancelChangeCountBooks_Click(object sender, EventArgs e)
        {
            _removeUnchangedBooksService.RemoveUnchangedBooks();
            this.Close();
        }
        private void AddCountBooksForm_FormClosing(object sender, FormClosingEventArgs e)
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